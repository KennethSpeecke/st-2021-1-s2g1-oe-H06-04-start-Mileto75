using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domain.Entities;
using Wba.Oefening.RateAMovie.Domains.Entities;

namespace Wba.Oefening.RateAMovie.Web.Helpers

{
    public class SelectListBuilder
    {
        public List<SelectListItem> BuildDirectorList(List<Director> directors)
        {
            var directorList = new List<SelectListItem>();
            string fullName = "";
            foreach(var director in directors)
            {
                fullName = $"{director.FirstName} {director.LastName}";
                directorList
                    .Add(new SelectListItem { Text = fullName,Value= director.Id.ToString() });
            }
            return directorList;
        }

        public List<SelectListItem> BuildCompaniesList(List<Company> companies)
        {
            var companyList = new List<SelectListItem>();
            
            foreach (var company in companies)
            {
                companyList
                    .Add(new SelectListItem { Text = company.Name, Value = company.Id.ToString() });
            }
            return companyList;
        }

        public List<SelectListItem> BuildActorList(List<Actor> actors)
        {
            var actorList = new List<SelectListItem>();
            string fullName = "";
            foreach (var actor in actors)
            {
                fullName = $"{actor.FirstName} {actor.LastName}";
                actorList
                    .Add(new SelectListItem { Text = fullName, Value = actor.Id.ToString() });
            }
            return actorList;
        }

    }
}
