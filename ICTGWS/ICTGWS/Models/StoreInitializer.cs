using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;
using System.IO;
using ICTGWS.Models;
using AutoMapper;

namespace ICTGWS.Models
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<ICTGWSContext>
    {
        protected override void Seed(ICTGWSContext context)
        {
            // Build the data, using CSV files
            // CSVHelper is a wonderful little program
            // It was added with the NuGet package manager

            CsvHelper.CsvReader csv = null;
            StreamReader sr = null;

            // Programs

            sr = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/data_programs.csv"));
            csv = new CsvHelper.CsvReader(sr);
            while (csv.Read())
            {
                var csvProgram = csv.GetRecord<ViewModels.ProgramAdd>();
                context.Programs.Add(Mapper.Map<Program>(csvProgram));
                context.SaveChanges();
            }
            sr.Close();
            sr = null;

            // Subjects - CPA
            // Fetch the CPA program

            Program program = null;
            program = context.Programs.SingleOrDefault(s => s.Code == "CPA");

            sr = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/data_subjects_cpa.csv"));
            csv = new CsvHelper.CsvReader(sr);
            while (csv.Read())
            {
                var csvSubject = csv.GetRecord<ViewModels.SubjectAdd>();
                Subject subject = context.Subjects.Add(Mapper.Map<Subject>(csvSubject));
                subject.Programs.Add(program);
                context.SaveChanges();
            }
            sr.Close();
            sr = null;

            // Subjects - BSD
            // Fetch the BSD program

            program = context.Programs.SingleOrDefault(s => s.Code == "BSD");

            sr = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/data_subjects_bsd.csv"));
            csv = new CsvHelper.CsvReader(sr);
            while (csv.Read())
            {
                var csvSubject = csv.GetRecord<ViewModels.SubjectAdd>();
                Subject subject = context.Subjects.Add(Mapper.Map<Subject>(csvSubject));
                subject.Programs.Add(program);
                context.SaveChanges();
            }
            sr.Close();
            sr = null;

            // Employees

            sr = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/data_employees.csv"));
            csv = new CsvHelper.CsvReader(sr);
            while (csv.Read())
            {
                var csvEmployee = csv.GetRecord<ViewModels.EmployeeAdd>();
                context.Employees.Add(Mapper.Map<Employee>(csvEmployee));
                context.SaveChanges();
            }
            sr.Close();
            sr = null;

        }

    }

}
