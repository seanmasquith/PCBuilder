using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PCBuilderApp.Models;
using PCBuilderApp.Services;
using PCBuilderApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilderApp.ViewModels
{
    //Inherits from BaseViewModel
    public partial class PCBuildViewModel : BaseViewModel
    {
        public ObservableCollection<PCBuild> PCBuilds { get; private set; } = new();

        public PCBuildViewModel()
        {
            Title = "PC Builds";
            GetPCBuildsList().Wait();
        }

        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string cpu;
        [ObservableProperty]
        string cpuCooler;
        [ObservableProperty]
        string gpu;
        [ObservableProperty]
        string motherboard;
        [ObservableProperty]
        string ram;
        [ObservableProperty]
        string storage;
        [ObservableProperty]
        string psu;
        //Case is a reserved word
        [ObservableProperty]
        string pcCase;

        [RelayCommand]

        async Task GetPCBuildsList()
        {
            if (IsLoading)
                return;

            try
            {
                IsLoading = true;
                if (PCBuilds.Any())
                    PCBuilds.Clear();

                var pcBuilds = App.PCBuilderService.GetPCBuilds();
                foreach (var build in pcBuilds)
                {
                    PCBuilds.Add(build);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Couldn't retrieve list", "Ok");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetPCBuildDetails(int id)
        {
            if (id == 0)
                return;

            await Shell.Current.GoToAsync($"{nameof(PCBuildDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task CreatePCBuild()
        {
            if (string.IsNullOrEmpty(name))
            {
                await Shell.Current.DisplayAlert("Invalid name", "Please enter a valid name", "Ok");
                await GetPCBuildsList();
            }

            var pcBuild = new PCBuild
            {
                PCBuildName = Name,
                PCCpu = Cpu,
                PCCpuCooler = CpuCooler,
                PCGpu = Gpu,
                PCMotherboard = Motherboard,
                PCRam = Ram,
                PCStorage = Storage,
                PCPsu = Psu,
                PCCase = PcCase
            };

            App.PCBuilderService.CreateBuild(pcBuild);
            await Shell.Current.DisplayAlert("Status", App.PCBuilderService.StatusMessage, "Ok");
            await GetPCBuildsList();
        }

        [RelayCommand]
        async Task DeletePCBuild(int id)
        {
            if (id==0)
            {
                await Shell.Current.DisplayAlert("Invalid record", "Try again.", "Ok.");
                return;
            }

            var result = App.PCBuilderService.DeleteBuild(id);
            if (result == 0) await Shell.Current.DisplayAlert("Delete Failed", "Insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Delete successful", "Record deleted", "Ok");
                await GetPCBuildsList();
            }
        }

        /*[RelayCommand]
        async Task UpdatePCBuild(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid record", "Try again.", "Ok.");
                return;
            }

            var result = App.PCBuilderService.UpdateBuild(id);
            if (result == 0) await Shell.Current.DisplayAlert("Delete Failed", "Insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Delete successful", "Record deleted", "Ok");
                await GetPCBuildsList();
            }
        }*/
    }
}