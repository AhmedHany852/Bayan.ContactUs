using Bayan.ContactUs.Core.Dto;
using Bayan.ContactUs.Core.Interfaces;
using Bayan.ContactUs.Data;
using Bayan.ContactUs.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bayan.ContactUs.Core.Repository
{
    public class ContactUsRepo : IContactUs
    {
        public readonly ContactUsContext _db;

        public ContactUsRepo(ContactUsContext db)
        {
            _db = db;
        }

        public ContactUsDto Add(ContactUsDto obj)
        {
            try
            {
                _db.ContactUs.Add(new Contactus() { Name = obj.Name, Email = obj.Email, Phone = obj.Email, Message = obj.Message });
                var res = _db.SaveChanges();
                if (res > 0)
                {

                    obj.Status = "Added";
                    return obj;
                }
                else
                    obj.Status = "Failed";
                    return obj;
            }
            catch (Exception) { throw; }
        }

        public ContactUsDto Delete(int id)
        {
            try
            {
                var filter = _db.ContactUs.FirstOrDefault(c => c.id == id);
                if (filter != null)
                    _db.ContactUs.Remove(filter);
                    var res = _db.SaveChanges();
                    if (res > 0)
                        return new ContactUsDto() { Status = "Deleted"};

                return new ContactUsDto() { };
            }
            catch (Exception) { throw; }
        }

        public ContactUsDto Get(int id)
        {
            try
            {
                var filter = _db.ContactUs.FirstOrDefault(c => c.id == id);
                if (filter != null)
                    return new ContactUsDto() {Name=filter.Name,Email=filter.Email,Phone=filter.Phone, Status = "Finded" };

                return new ContactUsDto() { };
            }
            catch (Exception) { throw; }
        }

        public List<ContactUsDto> GetAll()
        {
            try
            {
               return _db.ContactUs.Select(s=> new ContactUsDto { 
                
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    Message = s.Message
                
                }).ToList();

            }
            catch (Exception) { throw; }
        }

        public ContactUsDto Update(ContactUsDto obj)
        {
            try
            {
                var filter = _db.ContactUs.FirstOrDefault(c => c.id == obj.id);
                if (filter != null)
                    filter.Name = obj.Name;
                    filter.Email = obj.Email;
                    filter.Phone = obj.Phone;
                    filter.Message = obj.Message;   
                    _db.ContactUs.Add(filter);
                    _db.Entry(filter).State = EntityState.Modified;

                    var res = _db.SaveChanges();
                    if (res > 0)
                        return new ContactUsDto() { Status = "Deleted" };

                return new ContactUsDto() { };
            }
            catch (Exception) { throw; }
        }
    }
}
