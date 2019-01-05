using NebulaSync.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaSync
{
    class Program
    {
        static void Main(string[] args)
        {
            StartDishesSync();
            StartOrdersSync();

            Console.ReadLine();
        }

        static async void StartDishesSync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Синхронизация блюд");
                        var settings = new SettingsService();
                        var syncService = new SyncService(settings);
                        var result = await syncService.SyncDishesAsync();
                        Console.WriteLine("Синхронизация блюд завершена со статусом " + result);
                        Thread.Sleep(settings.DishesSyncDelay);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            });
        }

        static async void StartOrdersSync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Синхронизация заказов");
                        var settings = new SettingsService();
                        var syncService = new SyncService(settings);
                        var result = await syncService.SyncOrdersAsync();
                        Console.WriteLine("Синхронизация заказов завершена со статусом " + result);
                        Thread.Sleep(settings.OrdersSyncDelay);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            });
        }
    }
}
