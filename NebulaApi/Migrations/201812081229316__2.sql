﻿IF object_id(N'[dbo].[FK_dbo.Dishes_dbo.SubCategories_SubCategory_Id]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [FK_dbo.Dishes_dbo.SubCategories_SubCategory_Id]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_SubCategory_Id' AND object_id = object_id(N'[dbo].[Dishes]', N'U'))
    DROP INDEX [IX_SubCategory_Id] ON [dbo].[Dishes]
ALTER TABLE [dbo].[Categories] ADD [WorkshopType] [int] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Categories] ADD [ExternalId] [int] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Dishes] ADD [Price] [decimal](18, 2) NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Dishes] ADD [ExternalId] [int] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Dishes] ADD [IsActive] [bit] NOT NULL DEFAULT 0
ALTER TABLE [dbo].[Dishes] ADD [CreatedDate] [datetime] NOT NULL DEFAULT '1900-01-01T00:00:00.000'
DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Categories')
AND col_name(parent_object_id, parent_column_id) = 'UrlImage';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[Categories] DROP COLUMN [UrlImage]
DECLARE @var1 nvarchar(128)
SELECT @var1 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'WorkshopType';
IF @var1 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var1 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [WorkshopType]
DECLARE @var2 nvarchar(128)
SELECT @var2 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = '_id';
IF @var2 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var2 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [_id]
DECLARE @var3 nvarchar(128)
SELECT @var3 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'extId';
IF @var3 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var3 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [extId]
DECLARE @var4 nvarchar(128)
SELECT @var4 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'shopID';
IF @var4 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var4 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [shopID]
DECLARE @var5 nvarchar(128)
SELECT @var5 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'barcode';
IF @var5 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var5 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [barcode]
DECLARE @var6 nvarchar(128)
SELECT @var6 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'nameFull';
IF @var6 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var6 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [nameFull]
DECLARE @var7 nvarchar(128)
SELECT @var7 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'VAT';
IF @var7 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var7 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [VAT]
DECLARE @var8 nvarchar(128)
SELECT @var8 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'sellingPrice';
IF @var8 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var8 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [sellingPrice]
DECLARE @var9 nvarchar(128)
SELECT @var9 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'useGroupMarginRule';
IF @var9 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var9 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [useGroupMarginRule]
DECLARE @var10 nvarchar(128)
SELECT @var10 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'isAlcohol';
IF @var10 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var10 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [isAlcohol]
DECLARE @var11 nvarchar(128)
SELECT @var11 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'alcoholCode';
IF @var11 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var11 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [alcoholCode]
DECLARE @var12 nvarchar(128)
SELECT @var12 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'ownMarginRule';
IF @var12 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var12 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [ownMarginRule]
DECLARE @var13 nvarchar(128)
SELECT @var13 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'modified';
IF @var13 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var13 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [modified]
DECLARE @var14 nvarchar(128)
SELECT @var14 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = '__v';
IF @var14 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var14 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [__v]
DECLARE @var15 nvarchar(128)
SELECT @var15 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'isService';
IF @var15 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var15 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [isService]
DECLARE @var16 nvarchar(128)
SELECT @var16 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'uuid';
IF @var16 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var16 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [uuid]
DECLARE @var17 nvarchar(128)
SELECT @var17 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'isDelete';
IF @var17 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var17 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [isDelete]
DECLARE @var18 nvarchar(128)
SELECT @var18 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'code';
IF @var18 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var18 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [code]
DECLARE @var19 nvarchar(128)
SELECT @var19 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'isBeer';
IF @var19 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var19 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [isBeer]
DECLARE @var20 nvarchar(128)
SELECT @var20 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Dishes')
AND col_name(parent_object_id, parent_column_id) = 'SubCategory_Id';
IF @var20 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Dishes] DROP CONSTRAINT [' + @var20 + ']')
ALTER TABLE [dbo].[Dishes] DROP COLUMN [SubCategory_Id]
DROP TABLE [dbo].[SubCategories]
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201812081229316__2', N'NebulaApi.Migrations.Configuration',  0x1F8B0800000000000400ED5DDB6EDCB819BE2FD0771074D516DE191F36411AD8BB70C6766B6C7C40C6D9F62EA0257AAC4687890E591B459FAC177DA4BE42498992781629693493D40810D822F9F1E77FE2CFD3EFFFFEFB3FC73F3F45A1F315A65990C427EEC16CDF7560EC257E10AF4EDC227FF8E18DFBF34FBFFFDDF1B91F3D39BFD6F58E703DD432CE4EDCC73C5FBF9DCF33EF1146209B4581972659F290CFBC249A033F991FEEEFFF797E70308708C245588E73FCA188F32082E52FE8D745127B709D1720BC4A7C1866E43B2A5996A8CE358860B6061E3C71AFE17D1182D37530ABEABACE69180044C712860FAE03E238C9418EA87CFB3183CB3C4DE2D5728D3E80F0EE790D51BD0710669050FFB6AD6E3A90FD433C9079DBB086F28A2C4F224BC08323C29939DFBC177FDD86738877E788C7F9331E75C9BF13770172B84AD267D7E13B7BBB08535C5164EFAC6EB4E734457B8D22207DC1FFF69C4511E6450A4F6258E42908F79CDBE23E0CBC5FE0F35DF219C6277111863471883C54C67C409F6ED3640DD3FCF9037C20245FFAAE3367DBCDF9864D33AA4D3598CB383F3A749D6BD439B80F61237B6AE0CB3C49E15F600C53344EFF16E4394C638C014BEE09BD737DE1FFEBDE90B221AB719D2BF0F41EC6ABFCF1C4453FBACE45F004FDFA0BA1E0631C2023438DF2B4805D9DFC2D493F678FC91A77D37486B47DC61608C3D4A39E3FE1A182B09B5D7A9CCBECD4CB83AF0D65EF92248420B6C659A4108BE00CFD5743E19FEF82A86B6CC7F356D5F50690249F9188CE82ECD1CE06DA762F6620EB0B73669953922BD593FA6AAB0B4914A19E376E59DBD75D84750DBE06AB520C3C6AA9A1AEF301866571F618AC096BABA24F94624234135EA449F421099BA66CF9A73B90AE20666AA2A9B44C8AD4B320B2322619892DECA7AA12451E57D6F4DA90C657A869EF67F7849136265F567DB176B9D5DCAC51637FA8D5DCE1BAD745740FD36153D08BBBE06637EC0CC6F21A8269EA5C4B2FF3B49E8F5F2662B525C459906DDE1250E549CCED2B084A560DB5B849E2F4DB34F05A83865E1081D0756E53F413595EBF719DA50730D5F64EEEFB89D7B54EAC59A34AFC571909B4355AC7C514081E8B2D1DE4AA6A3BC4C03A9775D5ACD24FB3F535CC6775C35905799122B8DFD0F26D4623EE39C6ED5A9F7768EAF38E0EEE1F8EDEBC7A0DFCA3D73FC2A357D3FB3F89E51D1CBE31B2BC71EDFDF0D5EB517A55AAF1C70C4947AAC3B4BC3F916AAD228BA582364BAA8CA2D2186A7CB5AE51775FB531A5A27A4BABE201F5B184BA8BA9ADA1A677B3FD1A6BDCE97A8D8457AA16E68855E8C7B5FD16A3C0E9E47E1EA1F069043768D00B0A3C1F82341ABE28BC055986BC80FF578017051B8ED896D02B52A49CCB1C44EBCDC7878F49CCAD77A7E86B34D1DCFD965C000F2D50CE63DC6A30DEFBC4FB9C14F9795C06911F734F8C230D014621E7D4F360965D206586FE2229DAFD847E7136764FDB0E4316210822791CC239D24F75D5361691D710E2114535594CA223F57DB20A623352EBAA6A52AB1A9DA4926AB6A46230334A494D35A165854E3AAB5AA34579A584C60FF34AD8DD8FF3767D0B675B4162293EE68871537353D9D3AF202CC6EEAA9735944E607C6B286177DF1A4A32D1E7AF818FA31283C54F5D19C11BD597AFABBA6D8EA36C6A7360863975E7D3F800B5B91411652CEC2D83CBEC2204ABF61E8DDA6ED098FE01BDFC26455CBC48127F867133E6D2C208CB373462841F3E230ED11E9A65EF15C4813019CF2F41EE3D4264F2A50B42BC14A4C1547F07D2A6EAA1C8C08A551AF651A7E08379D7606D8571673084398EB3CD1877196351AB78C7D7FE0081FFDC543ED257BE039F2901FEA8AFBC00B107C32A56FB00BF1430A307F1CA44A4A75996784189C01C297347692C11685DE3989CABB51726EA73EA2B24BF008780C8384FDCFDD94CE474077873D44F81D3975FD81EFEC4F3801AAF9E0DEC8EBC8A44C5F63C7B53A483280DA06CB0CD2141172F2D062BDC68508A4479BDA18F38F4D092C1CB30070D5CB267ADA24FB781DD52C81EA3B0941EB87C4C7113579EC7C10757F81C6D01320FF8E22C8A6CD7B7204CC23A7133BC4B3428D081296E04F01E5886FC6D10E7625414C45EB006612797B896862B183CF6A60FBEE40CAE618C3BECE48449E7F2BD6F4C40D30F27942E0E5928A262D34225F3AE1D8C56EEC296F4243AD9B175A2D04BB27CDF8862EA39368172EA59624280F21C671B0A4AB6AA4C1580DFB7DA3505E536CC140A4A56D4932828CBB12D2828CB926F4E41AB1D4A53F973DB95BBA69EEC3EE9F4D3BA965D5BD04D861F3BA69AD5D6036A93A316CD5A8D1AC1D93D2E844FB9649D8CE8244BE58CEC74F02A82C19730676F15057833BEDDF310D60A42D4CDA1B0F72645203AA4EFC22A872445218BC00E00251546DD938309A1311B987780F056A5036C2DAF03945C891180040F63415C7DB6A5A58E845516B0F5399416964C861C2C6514BC4EF0D773A9AABA6BBCBCC51AEE3E34E3A35452B07EC3CD061A8B1D03EFD3D9E11BB086BBF927F244B31161B01541512E27D960F7811E3DE56E060F5D7C4721D108EDCE84D9DE84A9F4CCB6233A39DA8313B2AB73222FBA362B4CB72BA81110E7A6E183667781C29138CCC14C519DE38B8C31593CDB2C9FA98111616818D4B1D45530A91ECCE85CAA5D773797642B389B35DC202E71EB2D0597EAC18CCE25A2A3DD4C92AC222CD6118358C4C6FC23195B7D32D684A74DD9F1BC7A924E3E1CCF156FD78FAFC07A8D3C23F5969D7C7196D543F6C50F4BFB37DE518531F7186EF3C174D3539EA46005B952ECB57D7811A4597E0672700FF051D4C28F846AD2605C111ED55D0AF1B628C93A58AA9BE09FC9AD6DD5E373C9E285B4BE4003C46FBFCAB142710E963475705A0110825472C96391844514AB1763EAD6D5552FBA7DF5C51C813D67A591D8127344FAC9088D477F37476B1F8E305C6ABE9A23314F476830A640C43B9E73521796A98276099B09ACBE9A697347A06DA3D0D412B1874EEB5A6F46ADA9D36B1A84FA6C21F6FA992623F2FAE38B22F23A252A2259A10D53C16A7FA187F6291A6E46F1DA47C6AC90EBAFE648CC33631A8C297851E3C9D4780C47DAD3834EE93A9BB7B8AC9E908FE638D55B5B1AA4FA62A569ED435A4ED9DA8229631DF2549686209F5EA29B89AD51B576B3304666D7D8DE28F5CDB71DAE6F492CE2F275141135FBF0FDC5A486507A3072ACC4F830C551931AA5BE7942A3A86EA36C4D6CAA0D470B51F1271DF692EA44D88C4D91E7868C2FAE3E5962502FD60430AACC62BA611E1532B30E53628EC8BD1CA421B9220B2AE9F7810C9174412F3C0547E5352C426BE14520135F0BA5E6C892B78134B4A4B807B68466BECC1C55F27C900696145B8480CD5B42DE85EEF0ACA53C5FE8396D5507B4C3E62D05C666FCE138D31EF52E8B0926DBCF9658E4E5950046BEEFA42E294F617AEA52752A3F4C9714186AAFC3BC67629D8EF611961A9379A4C42EA6348FB4D478761ABB69BD608F67645B61FC5D89CE6D2FBE81C50E2B3E8392266894DFAC10B965E46108A4FC121645414FE29477C17ABB3F2D5528A8F083F2F6E165869FA2352F9F8C86CC1FD0592B09776BA4633B89AA69B26D2461B9F462485F45A861465005E9A597DDD201F568076B817881C6EC8086541EE8221417647A72BF8418C339286E01ED94522806DBAD10C2F13D5FA599B9C897E6F7E6F89E1C9D77E7A317CED2AB2A38EF5F3505A305E17396C368862BCC965FC2451894270575852B10070F30CBABB799EEE1FEC12197D47E7712CCCFB3CC67522669B2CCB3429B20374380B9DA997D614026B9F82B48BD4790FE21024F7FA491FA66712F291E9C07B20F0A9F05F23EB0C7906480F4D1CFF98632B67F1FFA24A44AEF233D2EE1F120BDDCAE2648B0DA70906290F004E032F6E1D389FBCFB2D55BE7F2EF9F9A867B4EF96EFEADB3EFFCCB961BCD9C63D7376966DEB36DEEF2EF43F9F9CCE17D744D9235FCFFDB84ECF26C7F1F8AC4E5B91E243D3A97F55035E0F355F7D184D1220E261FB5BFF97CD4DF5E1C22C1A217A296F34FDB7403F380FA907C0A23AEF5504C423482727773170F1AFF547EDE436B4664B35F0A547087188A59CC27551CC761EA4FBC7734ADB0395791CE564D59751D286136D9B0153555D301D4F44E41FCED1A1493E3578ACA1944FF94BE7D7CB32C9DEFA0494D9AB277D83429A6E51D0B6F1416AAD2EEF6C152A6DC954D98268395A7E0ED439A32FD6E9FB0824FBE6BEE86EA965B9C6A2487D4DF6CA0BE5B739390E37490A18B794C2DE006E42AEDA119DF589ACFD166C75B318BE768D8DB546D95F68C92A870849C8474268CBE49EF7AA56051BE6E31F1968E4DB215FD532EB13BEDC9FE04997FCC5235B2A7E5D6D914192C41FC9B94BBFAA5E8E8923717B9FE0C7F02A11BA7AC3492D5CE5ABDB14426B679CD71FD04C2EF99B673573275B62983A6CFE4D5F1A26574C532789E61BA5F3491720D4BC5B903C9E324B99FF499A1A6481937B5AEA9EE545BEC63EE7E5ACD1D533692114C9F2FEC7B5436D5A5EB1D5736AB14993BA66BDB9A3FB7AC69C653E8D6135E8AA97878B1928BA7FCED3A5D1ECBEA0AE289EBDF2748F8D5268226279DD0071DAF8BDDD0A5D29EB4B9FF84CEC8FE82D80F299076214F55284D92A94C91290336249A8D8A057CB658D64FF5C780E469A9549DB526ABECB0ADA2EE549D0F8BEF58705F42BF420D7DB7766325619776B0A48EBE5B4516395DDF6416D6F64DEAE8FB56E4669B3EFFA724D5A7C4ED2916F38AEBEF1D17B30D863C5A5E4FDE2FB239C07403154638D2D046CEDB6944E61624B8E1A49CD2947EB244C21D2190E20D9F3425F12E27E16446D29113B96BB9ABE0893C11F22EE7DC1C85298CCB573CF61C9F299B4AB1390A4BC6341D8B949AE2DB1B14761731BE9E50FD7606B360D542E0D74431F49880BBA973193F2475DCCF515457E1CEF5AE600E7C148D9FA679F000BC1C15E39B09E59FE0237F34EC3CBA87FE657C53E4EB22474386D17DC8CC3278FDA0EBBFCC1BCAD27C7CB3C6BF65630C019119E01B1D37F1BB2208DB3F76762139495440E08509B907806599E3FB00ABF60FB45D27B12110615FB39EBA83D13A4460D94DBC04F8E2A73D6D48FDDEC315F09EDB73631548B72058B61F9F056095822823186D7BF42BD2613F7AFAE97F6CB7DA4C38950000 , N'6.1.3-40302')