using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable
                                    , IHandler<CreateBoletoSubscriptionCommand>
                                    , IHandler<CreatePayPalSubscriptionCommand>
                                    , IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verificar se documento já esta cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Documents", "Este CPF já se encontra cadastrado");
            }
            //Verificar se email já esta cadastrado
            if (_repository.DocumentExists(command.Email))
            {
                AddNotification("Documents", "Este E-mail já se encontra cadastrado");
            }
            //Gerar VO
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.State, command.Country, command.ZipCode);

            //Gerar entidades
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode,
                                            command.BoletoNumber,
                                            command.PaidDate,
                                            command.ExipreDate,
                                            command.Total,
                                            command.TotalPaid,
                                            new Document(command.OwnerDocument, command.OwnerType),
                                            command.Owner,
                                            address,
                                            email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscritpion(subscription);
            //Aplicar Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            //Salvar Informações
            _repository.CreateSubscrption(student);
            //Enviar E-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Site", "Sua Assinatura foi criada");

            return new CommandResult(true, "Assinatura Realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //Verificar se documento já esta cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Documents", "Este CPF já se encontra cadastrado");
            }
            //Verificar se email já esta cadastrado
            if (_repository.DocumentExists(command.Email))
            {
                AddNotification("Documents", "Este E-mail já se encontra cadastrado");
            }
            //Gerar VO
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.State, command.Country, command.ZipCode);

            //Gerar entidades
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.LastTrasnsactionCode,
                                            command.PaidDate,
                                            command.ExipreDate,
                                            command.Total,
                                            command.TotalPaid,
                                            new Document(command.OwnerDocument, command.OwnerType),
                                            command.Owner,
                                            address,
                                            email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscritpion(subscription);
            //Aplicar Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            //Salvar Informações
            _repository.CreateSubscrption(student);
            //Enviar E-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Site", "Sua Assinatura foi criada");

            return new CommandResult(true, "Assinatura Realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //Fail Fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verificar se documento já esta cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Documents", "Este CPF já se encontra cadastrado");
            }
            //Verificar se email já esta cadastrado
            if (_repository.DocumentExists(command.Email))
            {
                AddNotification("Documents", "Este E-mail já se encontra cadastrado");
            }
            //Gerar VO
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.State, command.Country, command.ZipCode);

            //Gerar entidades
            var student = new Student(name, document, email, address);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.Owner,
                                            command.CardNumber,
                                            command.LastTransactionNumber,
                                            command.PaidDate,
                                            command.ExipreDate,
                                            command.Total,
                                            command.TotalPaid,
                                            new Document(command.OwnerDocument, command.OwnerType),
                                            command.Owner,
                                            address,
                                            email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscritpion(subscription);
            //Aplicar Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            //Salvar Informações
            _repository.CreateSubscrption(student);
            //Enviar E-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Site", "Sua Assinatura foi criada");

            return new CommandResult(true, "Assinatura Realizada com sucesso");
        }
    }
}