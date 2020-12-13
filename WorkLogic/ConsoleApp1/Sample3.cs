using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    #region Student
    /// <summary>
    /// 生徒
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 生徒名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 学校名
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 出席番号
        /// </summary>
        public string AttendanceNumber { get; set; }

        /// <summary>
        /// 学年
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName { get; set; }
    }
    #endregion

    #region TestResult
    /// <summary>
    /// テスト結果
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// 科目名
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 得点
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 生徒名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName { get; set; }
    }
    #endregion

    #region School
    /// <summary>
    /// 学校
    /// </summary>
    public class School
    {
        /// <summary>
        /// 学校名
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 場所
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 生徒名
        /// </summary>
        public string StudentName { get; set; }
    }
    #endregion

    #region Dto
    public class Dto
    {
        /// <summary>
        /// 生徒名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 学校名
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 出席番号
        /// </summary>
        public string AttendanceNumber { get; set; }

        /// <summary>
        /// 学年
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 科目名
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 得点
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 場所
        /// </summary>
        public string City { get; set; }
    }
    #endregion
    public class Sample3
    {
        List<Student> students = new List<Student>()
            {
                new Student { StudentName = "田中　一郎", AttendanceNumber = "0001", ClassName = "A", SchoolName = "西", SchoolYear = "3"},
                new Student { StudentName = "鈴木　二郎", AttendanceNumber = "0002", ClassName = "C", SchoolName = "西", SchoolYear = "3"},
                new Student { StudentName = "佐藤　三郎", AttendanceNumber = "0003", ClassName = "B", SchoolName = "西", SchoolYear = "3"}
            };

        List<TestResult> testResult = new List<TestResult>()
           {
                new TestResult {Subject = "国語", Point = 90, StudentName = "田中　一郎", ClassName = "A"},
                new TestResult {Subject = "数学", Point = 80, StudentName = "田中　一郎", ClassName = "A"},
                new TestResult {Subject = "英語", Point = 70, StudentName = "田中　一郎", ClassName = "A"},
                new TestResult {Subject = "国語", Point = 60, StudentName = "鈴木　二郎", ClassName = "C"},
                new TestResult {Subject = "数学", Point = 50, StudentName = "鈴木　二郎", ClassName = "C"},
                new TestResult {Subject = "英語", Point = 80, StudentName = "鈴木　二郎", ClassName = "C"},
                new TestResult {Subject = "国語", Point = 70, StudentName = "佐藤　三郎", ClassName = "B"},
                new TestResult {Subject = "数学", Point = 80, StudentName = "佐藤　三郎", ClassName = "B"},
                new TestResult {Subject = "英語", Point = 90, StudentName = "佐藤　三郎", ClassName = "B"},
                new TestResult {Subject = "英語", Point = 100, StudentName = "阿部　四郎", ClassName = "O"}
           };

        List<School> school = new List<School>()
            {
                new School { SchoolName = "西", StudentName = "田中　一郎",City = "Osaka"},
                new School { SchoolName = "西", StudentName = "鈴木　二郎",City = "Hyougo"},
                new School { SchoolName = "西", StudentName = "佐藤　三郎",City = "Nara"}
            };

        /// <summary>
        /// Student TestResult School 外部結合取得
        /// </summary>
        public void FindStudentTestSchool()
        {

            var studentTestResultQuery = students.GroupJoin(testResult,
                                             s => new { s.StudentName, s.ClassName },
                                             t => new { t.StudentName, t.ClassName },
                                             (s, t) => new
                                             {
                                                 Student = s,
                                                 TestResultList = t
                                             }).SelectMany(x => x.TestResultList.DefaultIfEmpty(),
                                                (s, t) => new
                                                {
                                                    s.Student,
                                                    TestResult = t
                                                });

            var studentTestSchoolQuery = studentTestResultQuery.GroupJoin(school,
                                                                t => new { t.Student.SchoolName, t.Student.StudentName },
                                                                s => new { s.SchoolName, s.StudentName },
                                                                (t, s) => new
                                                                {
                                                                    t.Student,
                                                                    t.TestResult,
                                                                    School = s
                                                                }).SelectMany(x => x.School.DefaultIfEmpty(),
                                                                               (t, s) => new Dto
                                                                               {
                                                                                   StudentName = t.Student.StudentName,
                                                                                   ClassName = t.Student.ClassName,
                                                                                   AttendanceNumber = t.Student.AttendanceNumber,
                                                                                   SchoolYear = t.Student.SchoolYear,
                                                                                   Subject = t.TestResult.Subject,
                                                                                   Point = t.TestResult.Point,
                                                                                   SchoolName = s.SchoolName,
                                                                                   City = s.City
                                                                               });
            foreach (var item in studentTestSchoolQuery)
            {
                Console.WriteLine(item.City);
            }
        }
    }
}
