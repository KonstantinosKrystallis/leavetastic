
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace LeaveTastic.Common.Services
{
    /// <summary>
    /// This service contains all services used throughout the application.
    /// </summary>
    public class HelperService
    {
        #region Services

        //Radzen services
        public readonly DialogService DialogService;
        public readonly NotificationService NotificationService;
        public readonly TooltipService TooltipService;
        public readonly ContextMenuService ContextMenuService;

        public readonly NavigationManager NavigationManager;

        public readonly HttpService HttpService;

        public HelperService(DialogService dialogService, NotificationService notificationService, TooltipService tooltipService, ContextMenuService contextMenuService,
            NavigationManager navigationManager, HttpService httpService)
        {
            DialogService = dialogService;
            NotificationService = notificationService;
            TooltipService = tooltipService;
            ContextMenuService = contextMenuService;
            NavigationManager = navigationManager;
            HttpService = httpService;
        }

        #endregion

        public Employee SelectedEmployee { get; set; } = new();
        public event Action<Employee> SelectedEmployeeChanged;

        public Task SelectEmployee(Employee employee)
        {
            SelectedEmployee = employee;
            SelectedEmployeeChanged?.Invoke(employee);
            return Task.CompletedTask;
        }
    }
}
