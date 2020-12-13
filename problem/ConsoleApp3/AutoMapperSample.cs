using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    /// <summary>
    /// AutoMapperSample
    /// </summary>
    public class AutoMapperSample
    {
        private readonly IMapper _mapper;

        public AutoMapperSample()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mapper"></param>
        public AutoMapperSample(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// メンバーが同じオブジェクト
        /// </summary>
        public void sample01() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Member, User>();
            });

            var mapper = config.CreateMapper();

            Member member = new Member
            {
                ID = 1,
                Name = "Na",
                Age = 20
            };

            var user = mapper.Map<User>(member);

            Console.WriteLine("ID:{0}", user.ID);
            Console.WriteLine("Name:{0}", user.ID);
            Console.WriteLine("Age:{0}", user.Age);    
        }

        /// <summary>
        /// 異なるメンバーをマッピング
        /// </summary>
        public void sample02()
        {
            // MapFromで紐づけ
            // Ignoreでマップしない
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<People, Student>()
                .ForMember(d => d.ID, o => o.MapFrom(s => s.PeopleID))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName + " " + s.LastName))
                .ForMember(d => d.Class, o => o.Ignore());
            });

            People people = new People()
            {
                PeopleID = 15,
                FirstName = "Narami",
                LastName = "Kiyokura",
                Class = "これはマップしない",
                PrefCode = 33
            };

            var mapper = config.CreateMapper();

            var student = mapper.Map<Student>(people);

            Console.WriteLine("ID:{0}", student.ID);
            Console.WriteLine("Name:{0}", student.Name);
            Console.WriteLine("Class:{0}", student.Class);
            Console.WriteLine("Club:{0}", student.Club);
        }

        public void Sample03() 
        {
            Member member = new Member();
            member.Age = 20;

            var user = _mapper.Map<User>(member);
            Console.WriteLine(user.Age);
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string Club { get; set; }
        }


        public class People
        {
            public int PeopleID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Class { get; set; }
            public int PrefCode { get; set; }
        }

        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Member
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
