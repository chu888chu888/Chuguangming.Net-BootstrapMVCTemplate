﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebConsole
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class SNSDBEntities : DbContext
    {
        public SNSDBEntities()
            : base("name=SNSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SNS_Note> SNS_Note { get; set; }
        public DbSet<SNS_User_Info> SNS_User_Info { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CheckUser(string user_name, string user_password)
        {
            var user_nameParameter = user_name != null ?
                new ObjectParameter("user_name", user_name) :
                new ObjectParameter("user_name", typeof(string));
    
            var user_passwordParameter = user_password != null ?
                new ObjectParameter("user_password", user_password) :
                new ObjectParameter("user_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CheckUser", user_nameParameter, user_passwordParameter);
        }
    
        public virtual ObjectResult<string> GetUserID(string user_name, string user_password)
        {
            var user_nameParameter = user_name != null ?
                new ObjectParameter("user_name", user_name) :
                new ObjectParameter("user_name", typeof(string));
    
            var user_passwordParameter = user_password != null ?
                new ObjectParameter("user_password", user_password) :
                new ObjectParameter("user_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetUserID", user_nameParameter, user_passwordParameter);
        }
    
        public virtual ObjectResult<string> GetUserName(string user_id)
        {
            var user_idParameter = user_id != null ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetUserName", user_idParameter);
        }
    
        public virtual int PostNote(string strNoteID, string strPosterID, string strContent, string posterTitle)
        {
            var strNoteIDParameter = strNoteID != null ?
                new ObjectParameter("strNoteID", strNoteID) :
                new ObjectParameter("strNoteID", typeof(string));
    
            var strPosterIDParameter = strPosterID != null ?
                new ObjectParameter("strPosterID", strPosterID) :
                new ObjectParameter("strPosterID", typeof(string));
    
            var strContentParameter = strContent != null ?
                new ObjectParameter("strContent", strContent) :
                new ObjectParameter("strContent", typeof(string));
    
            var posterTitleParameter = posterTitle != null ?
                new ObjectParameter("PosterTitle", posterTitle) :
                new ObjectParameter("PosterTitle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostNote", strNoteIDParameter, strPosterIDParameter, strContentParameter, posterTitleParameter);
        }
    
        public virtual int RegisterUser(string user_id, string user_email, string user_name, string user_password)
        {
            var user_idParameter = user_id != null ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(string));
    
            var user_emailParameter = user_email != null ?
                new ObjectParameter("user_email", user_email) :
                new ObjectParameter("user_email", typeof(string));
    
            var user_nameParameter = user_name != null ?
                new ObjectParameter("user_name", user_name) :
                new ObjectParameter("user_name", typeof(string));
    
            var user_passwordParameter = user_password != null ?
                new ObjectParameter("user_password", user_password) :
                new ObjectParameter("user_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegisterUser", user_idParameter, user_emailParameter, user_nameParameter, user_passwordParameter);
        }
    }
}
