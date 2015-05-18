using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaMa.Framework.Core.Web.HtmlControls.Bootstrap;
using LaMa.Framework.Core.Web.MVCWrappers;

namespace LaMa.Framework.Web.Testsite.Models.BootstrapControls
{
    public class SimpleTableControlVM
    {
        public List<User> Users { get; set; } 
    }

    public class SimpleTableControlPM : PresentationModel<SimpleTableControlVM>
    {
        public BootstrapTableControl BootstrapTableControl { get; set; }
        public override void Init()
        {
            var settings = BootstrapTableControlSettings.Create()
                                                        .SetStripped()
                                                        .SetBordered()
                                                        .SetCondensed();
            BootstrapTableControl = new BootstrapTableControl("usersTbl","usersTbl",settings);
            BootstrapTableControl.AddColumn<User,int>(x=>x.Id, true)
                .AddColumn<User,string>(x => x.Firstname)
                .AddColumn("Lastname")
                .AddColumn<User,DateTime>("Date Of Birth",x=>x.DateOfBirth)
                .AddColumn<User,bool>("Premium", x=>x.IsPremium);
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public bool IsPremium { get; set; }
    }
}