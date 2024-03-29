﻿
using LeaveTastic.Common.Components;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        public readonly IJSRuntime JsRuntime;

        public readonly HttpService HttpService;

        public readonly JsHelperService JsHelperService;

        public HelperService(DialogService dialogService, NotificationService notificationService, TooltipService tooltipService, ContextMenuService contextMenuService,
            NavigationManager navigationManager, IJSRuntime jsRuntime, HttpService httpService, JsHelperService jsHelperService)
        {
            DialogService = dialogService;
            NotificationService = notificationService;
            TooltipService = tooltipService;
            ContextMenuService = contextMenuService;
            NavigationManager = navigationManager;
            JsRuntime = jsRuntime;
            HttpService = httpService;
            JsHelperService = jsHelperService;
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

        public async Task<dynamic> OpenDialog<T>(string? title = null, Dictionary<string, object>? parameters = null) where T : ComponentBase
        {
            DialogOptions dialogOptions = new DialogOptions()
            {
                CloseDialogOnEsc = false,
                CloseDialogOnOverlayClick = false,
                Draggable = false,
                ShowClose = false,
                Height = "min(75%, auto)",
                Width = "min(75%, auto)",
            };

            return await DialogService.OpenAsync<TypedDynamicComponent<T>>(title, parameters, dialogOptions);
        }
    }
}
