using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CountryService
{
    public interface ICountryS
    {
        IQueryable<CountryDTO> GetCountrys();
    }
}
