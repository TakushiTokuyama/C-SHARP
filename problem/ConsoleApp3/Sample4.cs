using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{   // 三項演算子　sample
    public class Sample4
    {
        private class Room
        {
            public string OwnerId { get; set; }
            public string RoomCode { get; set; }
            public string RoomName { get; set; }
            public string Desk { get; set; }
            public string Chair { get; set; }
            public string Bed { get; set; }
        }

        private class Houce
        {
            public string HouseCode { get; set; }
            public string HouseName { get; set; }
            public string RoomCode { get; set; }
            public string OwnerId { get; set; }
        }

        private class Owner
        {
            public string OwnerId { get; set; }
            public string Name { get; set; }
        }

        private class OwnerHouseRoom
        {
            public string OwnerId { get; set; }
            public string RoomCode { get; set; }
            public string RoomName { get; set; }
            public string Name { get; set; }
            public string Desk { get; set; }
            public string Chair { get; set; }
            public string Bed { get; set; }
            public string HouseCode { get; set; }
            public string HouseName { get; set; }
        }

        public void Logic()
        {
            Owner owner1 = new Owner()
            {
                OwnerId = "1",
                Name = "田中"
            };

            string[] desks = { "田中の机", "山田の机", "鈴木の机" };

            string[] chairs = { "田中の椅子", "山田の椅子", "鈴木の椅子" };

            string tanakaDesk = string.Empty;

            var chairsAndIndex = chairs.Select((value, index) => new { ChairName = value, Index = index });


            string tanakaChair = string.Empty;

            foreach (var i in chairsAndIndex)
            {
                tanakaChair += i.ChairName == "田中の椅子" ? i.ChairName : "";
            }

            Room tanakaRoom = new Room()
            {
                OwnerId = owner1.OwnerId,
                RoomCode = "0001",
                RoomName = owner1.Name + "の部屋",
                Desk = desks.Contains("田中の机") ? desks[0] : "",
                Chair = chairs.Contains("田中の椅子") ? tanakaChair : "",
                Bed = owner1.Name == "田中" ? "田中のベッド" : ""
            };

            Console.WriteLine(tanakaRoom != null ? "田中の部屋には{0},{1},{2}がある。" : "田中の部屋は存在しません", tanakaRoom.Desk, tanakaRoom.Chair, tanakaRoom.Bed);

            List<Room> roomList = new List<Room>()
            {
                new Room {OwnerId = "1", RoomCode = "A1", RoomName = "", Desk = "", Chair = "", Bed = ""},
                new Room {OwnerId = "2", RoomCode = "B2", RoomName = "", Desk = "", Chair = "", Bed = ""},
                new Room {OwnerId = "3", RoomCode = "C3", RoomName = "", Desk = "", Chair = "", Bed = ""},
            };

            List<Owner> ownerList = new List<Owner>()
            {
                new Owner { OwnerId = "1", Name = "田中" },
                new Owner { OwnerId = "2", Name = "山田" },
                new Owner { OwnerId = "3", Name = "鈴木" }
            };

            List<Houce> houseList = new List<Houce>()
            {
                new Houce { HouseCode = "0001", HouseName = "田中の家", OwnerId = "1", RoomCode = "" },
                new Houce { HouseCode = "0002", HouseName = "山田の家", OwnerId = "2", RoomCode = "" },
                new Houce { HouseCode = "0003", HouseName = "鈴木の家", OwnerId = "3", RoomCode = "" },
            };

            var ownerRoom = ownerList.Join(roomList,
                o => o.OwnerId,
                r => r.OwnerId,
                (o, r) => new
                {
                    Owner = o,
                    Room = r
                });

            var ownerHouseRoom = ownerRoom.Join(houseList,
                                            or => or.Owner.OwnerId,
                                            h => h.OwnerId,
                                            (or, h) => new OwnerHouseRoom
                                            {
                                                OwnerId = or.Owner.OwnerId == "" ? tanakaRoom.OwnerId : or.Owner.OwnerId,
                                                HouseCode = h.HouseCode == "" ? h.HouseCode.IndexOf("0002", 0).ToString() : h.HouseCode,
                                                HouseName = h.HouseName,
                                                RoomCode = or.Room.RoomCode == "" ? tanakaRoom.OwnerId : or.Room.RoomCode,
                                                RoomName = or.Room.RoomName == "" ? tanakaRoom.OwnerId : or.Room.RoomName,
                                                Bed = or.Owner.OwnerId == "1" ? tanakaRoom.Bed :
                                                      or.Owner.OwnerId == "2" ? "山田のベッド" :
                                                      or.Owner.OwnerId == "3" ? "鈴木のベッド" : "",
                                                Chair = or.Owner.OwnerId == "1" ? tanakaRoom.Chair :
                                                        or.Owner.OwnerId == "2" ? "山田のベッド" :
                                                        or.Room.OwnerId == "3" ? "鈴木のベッド" : "",
                                                Desk = or.Room.OwnerId == "1" ? tanakaRoom.Desk :
                                                       or.Room.OwnerId == "2" ? "山田のベッド" :
                                                       or.Room.OwnerId == "3" ? "鈴木のベッド" : "",
                                                Name = or.Owner.Name
                                            }).ToList();

            foreach (var item in ownerHouseRoom)
                Console.WriteLine(item.Bed);
        }
    }
}
