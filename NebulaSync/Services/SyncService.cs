using NebulaSync.ExternalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace NebulaSync.Services
{
    public class SyncService
    {
        private readonly SettingsService settings;

        public SyncService(SettingsService settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<bool> SyncDishesAsync()
        {
            using (var client = new HttpClient())
            {
                var serializer = new JavaScriptSerializer();
                using (var db = new GARANTIA())
                {

                    var goods = db.Goods.Where(c => c.Deleted == 0).ToList();
                    var categories = db.GoodsGroups.ToList();
                    var content = new StringContent(serializer.Serialize(new { Goods = goods, Categories = categories }), Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(settings.SyncDishUri, content);
                    return result.IsSuccessStatusCode;
                }
            }
        }

        public async Task<bool> SyncOrdersAsync()
        {
            using (var client = new HttpClient())
            {
                var serializer = new JavaScriptSerializer();
                using (var db = new GARANTIA())
                {
                    var exportOrdersData = await client.GetStringAsync(settings.GetExportOrdersUri);
                    Console.WriteLine($"Получены данные о заказах для выгрузки {exportOrdersData}");
                    var exportOrders = new JavaScriptSerializer().Deserialize<Order[]>(exportOrdersData);
                    var handledOrders = new List<string>();
                    foreach (var exportOrder in exportOrders)
                    {
                        var tableNumber = exportOrder.TableNumber;
                        foreach (var dish in exportOrder.Dishes)
                        {
                            var objectId = db.Database.SqlQuery<Objec>("select * from Objects").ToList().FirstOrDefault(c => c.Code == tableNumber).ID;
                            var operation = new Operation
                            {
                                OperType = 33,
                                Acct = 0,
                                GoodID = dish.GoodId,
                                PartnerID = 2,
                                ObjectID = objectId,
                                OperatorID = exportOrder.OperatorId,
                                Qtty = dish.Quantity,
                                Sign = 0,
                                PriceIn = 0, // ???
                                PriceOut = 0,
                                VATIn = 0,
                                VATOut = 0,
                                Discount = 0,
                                CurrencyID = 1,
                                CurrencyRate = 0,
                                Date = DateTime.Now.Date,
                                Lot = "1",
                                LotID = 1,
                                Note = "",
                                SrcDocID = 0,
                                UserID = 4,
                                UserRealTime = DateTime.Now
                            };

                            db.Operations.Add(operation);
                        }

                        handledOrders.Add(exportOrder.TableNumber);
                    }

                    var content = new StringContent(serializer.Serialize(handledOrders), Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(settings.SetExportedOrdersUri, content);
                    if (result.IsSuccessStatusCode)
                    {
                        db.SaveChanges();
                        return true;
                    }

                    Console.WriteLine(await result.Content.ReadAsStringAsync());
                    return false;
                }
            }
        }

        public class Order
        {
            public string TableNumber { get; set; }
            public int OperatorId { get; set; }
            public dish[] Dishes { get; set; }
            public class dish
            {
                public int GoodId { get; set; }
                public int Quantity { get; set; }
            }
        }

    }
}
