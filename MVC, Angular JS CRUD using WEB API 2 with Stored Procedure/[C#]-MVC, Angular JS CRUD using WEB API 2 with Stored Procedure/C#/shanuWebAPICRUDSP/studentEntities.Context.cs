//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shanuWebAPICRUDSP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class studentDBEntities : DbContext
    {
        public studentDBEntities()
            : base("name=studentDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<StudentMaster> StudentMasters { get; set; }
    
        public virtual int USP_Student_Delete(Nullable<int> stdID)
        {
            var stdIDParameter = stdID.HasValue ?
                new ObjectParameter("StdID", stdID) :
                new ObjectParameter("StdID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_Student_Delete", stdIDParameter);
        }
    
        public virtual ObjectResult<string> USP_Student_Insert(string stdName, string email, string phone, string address)
        {
            var stdNameParameter = stdName != null ?
                new ObjectParameter("StdName", stdName) :
                new ObjectParameter("StdName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_Student_Insert", stdNameParameter, emailParameter, phoneParameter, addressParameter);
        }
    
        public virtual ObjectResult<USP_Student_Select_Result> USP_Student_Select(string stdName, string email)
        {
            var stdNameParameter = stdName != null ?
                new ObjectParameter("StdName", stdName) :
                new ObjectParameter("StdName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_Student_Select_Result>("USP_Student_Select", stdNameParameter, emailParameter);
        }
    
        public virtual ObjectResult<string> USP_Student_Update(Nullable<int> stdID, string stdName, string email, string phone, string address)
        {
            var stdIDParameter = stdID.HasValue ?
                new ObjectParameter("StdID", stdID) :
                new ObjectParameter("StdID", typeof(int));
    
            var stdNameParameter = stdName != null ?
                new ObjectParameter("StdName", stdName) :
                new ObjectParameter("StdName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_Student_Update", stdIDParameter, stdNameParameter, emailParameter, phoneParameter, addressParameter);
        }
    }
}
