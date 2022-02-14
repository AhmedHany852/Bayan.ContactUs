using Bayan.ContactUs.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayan.ContactUs.Core.Interfaces
{
    public interface IContactUs
    {
        ContactUsDto Add(ContactUsDto obj);
        ContactUsDto Delete(int id);
        ContactUsDto Update(ContactUsDto obj);
        ContactUsDto Get(int id);
        List<ContactUsDto> GetAll();


    }
}
