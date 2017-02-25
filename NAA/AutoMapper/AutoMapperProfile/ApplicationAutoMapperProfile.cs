using AutoMapper;
using NAA.Data;
using NAA.Models;

namespace NAA.AutoMapper.AutoMapperProfile
{

    //
    public class ApplicationAutoMapperProfile: Profile
    {
        public ApplicationAutoMapperProfile():base()
        {
            CreateMap<Application,ApplicationViewModel>()
                .ForMember(d=>d.ApplicantName,s=>s.MapFrom(m=>m.Applicant.ApplicantName));
            CreateMap<ApplicationViewModel, Application>();
        }
    }
}