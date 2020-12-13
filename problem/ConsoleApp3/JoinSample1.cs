using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    public class JoinSample1
    {
        public class Order
        {
            public string ReceiptNumber { get; set; }
            public string ProductName { get; set; }
            public string PersonInCharge { get; set; }
        }

        public class Stock
        {
            public string StockId { get; set; }
            public string ProductName { get; set; }
            public string StockPlace { get; set; }
        }

        public class OrderStockDto
        { 
            public string ReceiptNumber { get; set; }
            public string ProductName { get; set; }
            public string PersonInCharge { get; set; }
            public string StockId { get; set; }
            public string StockPlace { get; set; }
        }

        public void Logic() 
        {
            // 注文
            List<Order> order = new List<Order>()
            {
                new Order { ReceiptNumber = "0001" , ProductName = "お茶", PersonInCharge = "A" },
                new Order { ReceiptNumber = "0002" , ProductName = "緑茶", PersonInCharge = "B" },
                new Order { ReceiptNumber = "0003" , ProductName = "紅茶", PersonInCharge = "B" },
                new Order { ReceiptNumber = "0004" , ProductName = "コーヒー", PersonInCharge = "A" },
                new Order { ReceiptNumber = "0005" , ProductName = "麦茶", PersonInCharge = "C" },
            };

            // 在庫
            List<Stock> stock = new List<Stock>()
            {
                new Stock{ StockId = "1", ProductName = "お茶" , StockPlace = "大阪"},
                new Stock{ StockId = "2", ProductName = "麦茶" , StockPlace = "東京"},
                new Stock{ StockId = "3", ProductName = "紅茶" , StockPlace = "大阪"},
                new Stock{ StockId = "4", ProductName = "お茶" , StockPlace = "東京" },
                new Stock{ StockId = "5", ProductName = "力水", StockPlace = "奈良"}
            };

            // 内部結合
            var innerJoinOrderStock = order.Join(stock,
                                            o => o.ProductName,
                                            s => s.ProductName,
                                            (o, s) => new OrderStockDto
                                            {
                                                ReceiptNumber = o.ReceiptNumber,
                                                ProductName = o.ProductName,
                                                PersonInCharge = o.PersonInCharge,
                                                StockId = s.StockId,
                                                StockPlace = s.StockPlace
                                            });
            // 外部結合
            var outerJoinOrderStock = order.GroupJoin(stock,
                                            o => o.ProductName,
                                            s => s.ProductName,
                                            (o, s) => new
                                            {
                                                Order = o,
                                                stockList = s.DefaultIfEmpty()
                                            }).SelectMany(x => x.stockList,
                                                            (o, s) => new OrderStockDto
                                                            {
                                                                ReceiptNumber = o.Order.ReceiptNumber,
                                                                ProductName = o.Order.ProductName,
                                                                PersonInCharge = o.Order.PersonInCharge,
                                                                StockId = s != null ? s.StockId : "null",
                                                                StockPlace = s != null ? s.StockPlace : "null"

                                                            });
            // 内部結合結果表示
            foreach (var item in innerJoinOrderStock)
            {
                Console.WriteLine("ReceiptNumber:{0}\tProductName:{1}\tPersonInCharge:{2}\tStockId:{3}\tStockPlace:{4}", item.ReceiptNumber, item.ProductName, item.PersonInCharge, item.StockId, item.StockPlace);
            }

            Console.WriteLine("--------------------------");

            // 外部結合結果表示
            foreach (var item in outerJoinOrderStock)
            {
                Console.WriteLine("ReceiptNumber:{0}\tProductName:{1}\tPersonInCharge:{2}\tStockId:{3}\tStockPlace:{4}", item.ReceiptNumber, item.ProductName, item.PersonInCharge, item.StockId, item.StockPlace);
            }
        }

        public class KojoNo
        {
            public string KojoId { get; set; }
            public string KojoBasyo { get; set; }
        }

        public class Zaiko
        {
            public string ZaikoId { get; set; }
            public string Zaibasyo { get; set; }
        }

        public class KojoZaikoDto
        {
            public KojoNo KojoNo { get; set; }
            public Zaiko Zaiko { get; set; }
        }

        /// <summary>
        /// 異なるメンバー間のjoin
        /// </summary>
        public void Logic2() 
        {
            var kojoNo = new List<KojoNo>
            {
                new KojoNo { KojoId = "1" , KojoBasyo = "ABCD" },
                new KojoNo { KojoId = "2" , KojoBasyo = "BDFG" },
                new KojoNo { KojoId = "3" , KojoBasyo = "ATGH" }
            };

            var zaiko = new List<Zaiko>
            {
                new Zaiko { ZaikoId = "1", Zaibasyo = "ABCD" },
                new Zaiko { ZaikoId = "2", Zaibasyo = "BGHT" },
                new Zaiko { ZaikoId = "3", Zaibasyo = "AEED" }
            };

            var kojoZaikoQuery = kojoNo.GroupJoin(zaiko,
                                    k => k.KojoBasyo,
                                    z => z.Zaibasyo,
                                    (k, z) => new
                                    {
                                        KojoNo = k,
                                        ZaikoList = z
                                    }).SelectMany(x => x.ZaikoList.DefaultIfEmpty(),
                                    (k, z) => new KojoZaikoDto
                                    {
                                        KojoNo = k.KojoNo,
                                        Zaiko = z
                                    }).ToList();

            kojoZaikoQuery.ForEach(x => Console.WriteLine(x.KojoNo.KojoBasyo));
        }
    }
}
