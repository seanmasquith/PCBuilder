using CommunityToolkit.Mvvm.ComponentModel;
using PCBuilderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PCBuilderApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class PCBuildDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        PCBuild pcBuild;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            PcBuild = App.PCBuilderService.GetPCBuild(Id);
        }
    }
}
