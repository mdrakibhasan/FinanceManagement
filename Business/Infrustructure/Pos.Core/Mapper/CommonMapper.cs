using AutoMapper;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Core.Mapper
{
    public class CommonMapper : Profile
    {
        public CommonMapper()
        {
           
            CreateMap<VmAccountsHeadType, Model.AccountsHeadType>().ReverseMap();
            CreateMap<VmAccountsHead, Model.AccountsHead>().ReverseMap();
            CreateMap<VmAccountTransactionMst, Model.AccountTransactionMst>().ReverseMap();
            CreateMap<VmAccountTransactionDtl, Model.AccountTransactionDtl>().ReverseMap();
            CreateMap<VmAccountsReportSettingDetails, Model.AccountsReportSettingDetails>().ReverseMap();
            CreateMap<VmAccountsReportSetting, Model.AccountsReportSetting>().ReverseMap();
        }
    }
}
