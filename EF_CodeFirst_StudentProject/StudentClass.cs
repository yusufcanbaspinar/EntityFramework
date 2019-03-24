namespace EF_CodeFirst_StudentProject
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class StudentClass : DbContext
    {
        // Your context has been configured to use a 'StudentClass' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF_CodeFirst_StudentProject.StudentClass' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentClass' 
        // connection string in the application configuration file.
        public StudentClass()
            : base("name=StudentClass")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Class_> Classes { get; set; }

    }
    public class Student
    {
        [Key, DisplayName("Identity No")]
        public long TCID { get; set; }
        [StringLength(80)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FullName cant be empty")]
        public string FullName { get; set; }
        public int Yas { get; set; }
        public int Class_Id { get; set; }
       
        public virtual Class_ Class_ { get; set; }
    }

    public class Class_
    {
        public Class_()
        {
            this.Students = new HashSet<Student>();
        }

        [Key]
        public int Class_ID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}