namespace MyCompany.Vacation.AzureEventBusPlugin.MessageHandlers
{
    using AutoMapper;
    using Microsoft.ServiceBus.Messaging;
    using MyCompany.Common.EventBus;
    using MyCompany.Vacation.Data;
    using MyCompany.Vacation.Data.Repositories;
    using MyCompany.Vacation.Model;
    using System;
    using System.Threading;

    /// <summary>
    /// Represent the add new employee picture handler
    /// </summary>
    public class AddNewEmployeePictureMessageHandler
        : MessageHandler
    {
        ///<inheritdoc/>
        public override bool CanExecute(BrokeredMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            return message.ContentType == StaffActions.AddEmployeePicture;
        }

        ///<inheritdoc/>
        public override void Handle(BrokeredMessage message)
        {
            var employeeRepository = new EmployeeRepository(new MyCompanyContext());
            var employeePictureRepository = new EmployeePictureRepository(new MyCompanyContext());

            var dto = message.GetBody<EmployeePictureDTO>();
            var employeePicture = Mapper.Map<EmployeePicture>(dto);

            var employee = employeeRepository.Get(employeePicture.EmployeeId);
            if (null == employee)
            {
                Thread.Sleep(1000);
            }
            employeePictureRepository.Add(employeePicture);
        }
    }
}
