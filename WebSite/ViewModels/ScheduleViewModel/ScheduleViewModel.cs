﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebSite.ViewModels.ScheduleViewModel
{
    public class ScheduleViewModel
    {
        private WebSiteDBEntities db = new WebSiteDBEntities();

        public int ID { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string Type { get; set; }
        public string Room { get; set; }
        public string Topic { get; set; }
        public string FilePath { get; set; }
        public int TeacherID { get; set; }
        public string title { get; set; }
        public int? Course { get; set; }
        public string TeacherName { get; set; }
        public int DisciplineID { get; set; }
        public string DisciplineName { get; set; }

        public ScheduleViewModel()
        {

        }


        public ScheduleViewModel(int id, DateTime Start, DateTime End, string type, string room, string topic, string filePath, int teacherID, int disciplineID)
        {
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
            this.ID = id;
            this.start = Start.ToString(isoDateTimeFormat.SortableDateTimePattern);
            this.end = End.ToString(isoDateTimeFormat.SortableDateTimePattern);
            this.Type = type;
            this.Room = room;
            this.Topic = topic;
            this.FilePath = filePath;
            this.TeacherID = teacherID;
            this.TeacherName = GetTeacherName(teacherID);
            this.title = id.ToString();
            this.Course = GetCourse(disciplineID);
            this.DisciplineName = GetDisciplineName(disciplineID);
        }

        //public ScheduleViewModel(int id, DateTime Start, DateTime End, string type, string room, string topic, string filePath, int teacherID, int disciplineID)
        //{
        //    var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
        //    this.ID = id;
        //    this.start = Start.ToString(isoDateTimeFormat.SortableDateTimePattern);
        //    this.end = End.ToString(isoDateTimeFormat.SortableDateTimePattern);
        //    this.Type = type;
        //    this.Room = room;
        //    this.Topic = topic;
        //    this.FilePath = filePath;
        //    this.TeacherID = teacherID;
        //    this.DisciplineID = disciplineID;
        //}

       
        private string GetTeacherName(int teacherID)
        {
            string name = "";
            name = db.tblTeachers
                .Where(t => t.ID == teacherID)
                .Select(t => t.FirstName)
                .First()
                .ToString() 
                + " " + 
                db.tblTeachers.Where(t => t.ID == teacherID)
                .Select(t => t.LastName)
                .First()
                .ToString();
            return name;
        }

        private int? GetCourse(int id)
        {
            int? course = -1;
            course = db.tblDisciplines.Where(d => d.ID == id).Select(d => d.Course).First();
            return course;
        }

        private string GetDisciplineName(int id)
        {
            var name= "";
            name = db.tblDisciplines.Where(d => d.ID == id).Select(d => d.Name).First().ToString();
            return name;
        }
    }
}