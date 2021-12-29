using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DocumentType = Medilab.BusinessObjects.Utils.DocumentType;

namespace Medilab.BusinessObjects.Configuration
{
    public class Client
    {
        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DocumentType DocumentType { set; get; }
        public string Cuit { get; set; }
        public string AditionalInformation { get; set; }
        public byte[] LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Address.Address> Addresses { set; get; }
        public string PhoneNumber { set; get; }
        public string FaxNumber { set; get; }
        public string EmailAddress { set; get; }
        public IEnumerable<ClientArea> Areas { set; get; }
        public int ClientNumber { set; get; }
        public Iva IvaCondition { set; get; }
        public ClientInvoiceProfile InvoiceProfile { set; get; }
        public string Logo { set; get; }

        #endregion
        
        #region Methods
        private Client()
        { }
        public Client(Guid clientId)
        { 
            Id = clientId; 
        }
        internal static Client GetClient (DataAccess.Client databaseClient)
        {
            var client = new Client
                             {
                                 Id = databaseClient.ClientId,
                                 AditionalInformation = databaseClient.ClientAditionalInformation,
                                 DocumentType = (DocumentType)databaseClient.DocumentTypeId,
                                 Cuit = databaseClient.ClientCuit,
                                 EmailAddress = databaseClient.ClientEmailAddress,
                                 FaxNumber = databaseClient.ClientFaxNumber,
                                 PhoneNumber = databaseClient.ClientPhoneNumber,
                                 Name = databaseClient.ClientName,
                                 IsDeleted = databaseClient.ClientIsDeleted,
                                 LastUpdated = databaseClient.LastUpdated,
                                 ClientNumber = databaseClient.ClientNumber,
                                 IvaCondition = (Iva) databaseClient.IvaConditionId,
                                 Logo =  databaseClient.ClientLogo
                             };
            client.Addresses = Address.Address.GetAddressesByOwner(client.Id);
            client.Areas = ClientArea.GetAreasByClient(client.Id);
            if (databaseClient.InvoiceProfileId.HasValue)
            {
                client.InvoiceProfile = ClientInvoiceProfile.GetInviceProfile(databaseClient.InvoiceProfileId.Value);
            }
            return client;
        }
        public Client Save()
        {
            try
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException as SqlException;
                if (innerException != null)
                {
                    var errorCode = (innerException).ErrorCode;
                    if (errorCode == -2146232060)
                    {
                        throw new Exception("El número de cliente ya existe");
                    }
                }
                throw;
            }
        }
        private Client Update()
        {
            using (var context = new MedilabEntities())
            {
                var client = (from c in context.Client
                              where c.ClientId == Id
                              select c).First();
                if (Tools.IsRecordChanged(client.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                var ivaCondition = (int) IvaCondition;
                var documentTypeId = (int)DocumentType;
                client.ClientName = Name;
                client.DocumentTypeId = documentTypeId;
                client.ClientCuit = Cuit;
                client.ClientAditionalInformation = AditionalInformation;
                client.ClientPhoneNumber = PhoneNumber;
                client.ClientFaxNumber = FaxNumber;
                client.ClientEmailAddress = EmailAddress.Trim();
                client.IvaConditionId = ivaCondition;
                client.ClientNumber = ClientNumber;
                if (!string.IsNullOrEmpty(Logo))
                {
                   client.ClientLogo = string.Concat(client.ClientId.ToString(), ".", Logo);
                }

                foreach (var address in Addresses)
                {
                    address.Owner = Id;
                    address.Save();
                }
                foreach (var clientArea in Areas)
                {
                    clientArea.ClientId = Id;
                    clientArea.Save(context);
                }
                if (InvoiceProfile != null)
                {
                    client.InvoiceProfileId = InvoiceProfile.Id;
                }
                else
                {
                    client.InvoiceProfileId = null;
                }
                var modifiedFields = Utilities.GetModifiedFields(context, client.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Client, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }
        private Client Insert()
        {
            
            using (var context = new MedilabEntities())
            {
                var documentTypeId = (int)DocumentType;
                var ivaCondition = (int) IvaCondition;
                var client = new DataAccess.Client
                                 {
                                     ClientId = Id = Guid.NewGuid(),
                                     DocumentTypeId = documentTypeId,
                                     ClientCuit = Cuit,
                                     ClientAditionalInformation = AditionalInformation,
                                     ClientName = Name,
                                     ClientIsDeleted = false,
                                     ClientPhoneNumber = PhoneNumber,
                                     ClientFaxNumber = FaxNumber,
                                     ClientEmailAddress = EmailAddress.Trim(),
                                     ClientNumber = ClientNumber,
                                     IvaConditionId = ivaCondition
                                 };
                if (!string.IsNullOrEmpty(Logo))
                {
                    string filename = string.Concat(client.ClientId.ToString(), ".", Logo);
                    client.ClientLogo = filename;
                }
                foreach (var address in Addresses)
                {
                    address.Owner = Id;
                    address.Save(context);
                }
                foreach (var clientArea in Areas)
                {
                    clientArea.ClientId = Id;
                    clientArea.Save(context);
                }
                if (InvoiceProfile != null)
                {
                    client.InvoiceProfileId = InvoiceProfile.Id;
                }
                else
                {
                    client.InvoiceProfileId = null;
                }
                context.AddToClient(client);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Client, AuditOperations.Insert, Id,
                                     client.ClientName);
                context.SaveChanges();
                return this;
            }
        }
        public static bool Delete(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var client = (from c in context.Client
                                   where c.ClientId == clientId
                                   select c).First();

                client.ClientIsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Client, AuditOperations.Delete, clientId, client.ClientName);
                context.SaveChanges();
                return true;
            }
        }
        public static Client GetClient(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var client = (from c in context.Client
                                 where c.ClientId == clientId && !c.ClientIsDeleted
                                 select c).FirstOrDefault();
                if (client != null)
                {
                    return GetClient(client);
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }
        public static IEnumerable<Client> GetClientList()
        {
            using (var context = new MedilabEntities())
            {
                var clientList = (from c in context.Client
                                       where !c.ClientIsDeleted
                                       orderby c.ClientName
                                       select c).ToList();

                return ClientList(clientList);
            }
        }
        public static IEnumerable<ClientListDto> GetDisplayClientList()
        {
            using (var context = new MedilabEntities())
            {
                var clientList = (from c in context.Client
                                  where !c.ClientIsDeleted
                                  orderby c.ClientName
                                  select new ClientListDto
                                  {
                                      Id = c.ClientId,
                                      DocumentType = (DocumentType)c.DocumentTypeId,
                                      ClientNumber = c.ClientNumber,
                                      Name = c.ClientName,
                                      Cuit = c.ClientCuit,
                                      AditionalInformation = c.ClientAditionalInformation
                                  }).ToList();

                return clientList;
            }
        }
        public static IEnumerable<ListItemDto<Guid>> GetClients()
        {
            return GetClientsWithNumer();
        }
        public static IEnumerable<ClientListItemDto> GetClientsWithNumer()
        {
            using (var context = new MedilabEntities())
            {
                var clientList = (from c in context.Client
                                  where !c.ClientIsDeleted
                                  orderby c.ClientName
                                  select new { c.ClientId, c.ClientName, c.ClientNumber }).ToList();
                return clientList.Select(client => new ClientListItemDto
                {
                    Id = client.ClientId,
                    Value = client.ClientName,
                    Number = client.ClientNumber
                }).ToList();
            }
        }
        public static IEnumerable<ListItemDto<Guid>> GetClientsForInvoice(InvoiceType type)
        {
            var allowedTypes = new List<int>();
            switch (type)
            {
                case InvoiceType.A:
                    allowedTypes.Add((int)Iva.IVA_Responsable_Inscripto);
                    allowedTypes.Add((int)Iva.IVA_Responsable_No_Inscripto);
                    allowedTypes.Add((int)Iva.IVA_No_Responsable);
                    allowedTypes.Add((int)Iva.Sujeto_No_Categorizado);
                    allowedTypes.Add((int)Iva.IVA_Responsable_Inscripto_Agente_de_Percepcion);
                    allowedTypes.Add((int)Iva.Pequeño_Contribuyente_Eventual);
                    allowedTypes.Add((int)Iva.Pequeño_Contribuyente_Eventual_Social);
                    break;
                case InvoiceType.B:
                    allowedTypes.Add((int)Iva.IVA_Sujeto_Exento);
                    allowedTypes.Add((int)Iva.Consumidor_Final);
                    allowedTypes.Add((int)Iva.Responsable_Monotributo);
                    allowedTypes.Add((int)Iva.Proveedor_del_Exterior);
                    allowedTypes.Add((int)Iva.Cliente_del_Exterior);
                    allowedTypes.Add((int)Iva.IVA_Liberado_Ley_19640);
                    allowedTypes.Add((int)Iva.Monotributista_Social);
                    break;
                case InvoiceType.C:
                case InvoiceType.ReciboA:
                case InvoiceType.NotaCreditoA:
                case InvoiceType.NotaCreditoB:
                case InvoiceType.NotaDebitoA:
                case InvoiceType.NotaDebitoB:
                    throw new Exception("Condición IVA no encontrada");
                default:
                    throw new Exception("Condición IVA no encontrada");
            }
            using (var context = new MedilabEntities())
            {
                var clientList = (from c in context.Client
                                  where !c.ClientIsDeleted &&
                                  allowedTypes.Contains(c.IvaConditionId)
                                  orderby c.ClientName
                                  select new { c.ClientId, c.ClientName, c.ClientNumber }).ToList();
                return clientList.Select(client => new ListItemDto<Guid>
                {
                    Id = client.ClientId,
                    Value = client.ClientName,
                }).ToList();
            }
        }
        public static IEnumerable<ListItemDto<Guid>> GetClientsForInvoiceWithPendingItems(InvoiceType type)
        {
            var allowedTypes = new List<int>();
            switch (type)
            {
                case InvoiceType.A:
                    allowedTypes.Add((int)Iva.IVA_Responsable_Inscripto);
                    allowedTypes.Add((int)Iva.IVA_Responsable_No_Inscripto);
                    allowedTypes.Add((int)Iva.IVA_No_Responsable);
                    allowedTypes.Add((int)Iva.Sujeto_No_Categorizado);
                    allowedTypes.Add((int)Iva.IVA_Responsable_Inscripto_Agente_de_Percepcion);
                    allowedTypes.Add((int)Iva.Pequeño_Contribuyente_Eventual);
                    allowedTypes.Add((int)Iva.Pequeño_Contribuyente_Eventual_Social);
                    break;
                case InvoiceType.B:
                    allowedTypes.Add((int)Iva.IVA_Sujeto_Exento);
                    allowedTypes.Add((int)Iva.Consumidor_Final);
                    allowedTypes.Add((int)Iva.Responsable_Monotributo);
                    allowedTypes.Add((int)Iva.Proveedor_del_Exterior);
                    allowedTypes.Add((int)Iva.Cliente_del_Exterior);
                    allowedTypes.Add((int)Iva.IVA_Liberado_Ley_19640);
                    allowedTypes.Add((int)Iva.Monotributista_Social);
                    break;
                case InvoiceType.C:
                case InvoiceType.ReciboA:
                case InvoiceType.NotaCreditoA:
                case InvoiceType.NotaCreditoB:
                case InvoiceType.NotaDebitoA:
                case InvoiceType.NotaDebitoB:
                    throw new Exception("Condición IVA no encontrada");
                default:
                    throw new Exception("Condición IVA no encontrada");
            }
            using (var context = new MedilabEntities())
            {
                const int completedItemStatus = (int)Utils.ClinicalExamStatus.Realizada;
                var clientList = (from item in context.MedicalHistoryPractice
                                  where item.Status >= completedItemStatus &&
                                        item.InvoiceId == null && !item.MedicalHistory.Client.ClientIsDeleted && allowedTypes.Contains(item.MedicalHistory.Client.IvaConditionId)
                                  orderby item.MedicalHistory.PatiendId, item.GroupId
                                  select new { item.MedicalHistory.Client.ClientId, item.MedicalHistory.Client.ClientName, item.MedicalHistory.Client.ClientNumber }).ToList();

                var listToFilter =
                clientList.Select(client => new ClientListItemDto
                {
                    Id = client.ClientId,
                    Value = client.ClientName,
                    Number = client.ClientNumber
                }).ToList();


                var filteredList = new List<ClientListItemDto>();
                foreach (var item in listToFilter.Where(x => !filteredList.Any(b => x.Id == b.Id)))
                {
                    filteredList.Add(item);
                }

                return filteredList.OrderBy(x => x.Value);

            }
        }
        private static IEnumerable<Client> ClientList(IEnumerable<DataAccess.Client> clientList)
        {
            return clientList.Select(client => new Client
                {
                    Id = client.ClientId,
                    Name = client.ClientName,
                    DocumentType = (DocumentType)client.DocumentTypeId,
                    Cuit = client.ClientCuit,
                    AditionalInformation = client.ClientAditionalInformation,
                    LastUpdated = client.LastUpdated,
                    PhoneNumber = client.ClientPhoneNumber,
                    Addresses = Address.Address.GetAddressesByOwner(client.ClientId),
                    Areas = ClientArea.GetAreasByClient(client.ClientId),
                    ClientNumber = client.ClientNumber,
                    IvaCondition = (Iva)client.IvaConditionId,
                    Logo = client.ClientLogo
                }).ToList();
        }
        public static IEnumerable<Client> GetFilteredClientList(string filterCriteria)
        {
            int clientNumber;
            var isNumericFilter = int.TryParse(filterCriteria, out clientNumber);
            using (var context = new MedilabEntities())
            {
                var clientList = new List<DataAccess.Client>();
                if(isNumericFilter)
                {
                    clientList = (from c in context.Client
                                  where !c.ClientIsDeleted &&
                                        c.ClientNumber == clientNumber
                                  orderby c.ClientName
                                  select c).ToList();
                }
                else
                {
                    clientList = (from c in context.Client
                                  where !c.ClientIsDeleted &&
                                        (c.ClientName.Contains(filterCriteria) || c.ClientCuit.Contains(filterCriteria))
                                  orderby c.ClientName
                                  select c).ToList();
                }
                return ClientList(clientList);
            }
        }
        public static bool ExistCode(int number, Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                return (from p in context.Client where p.ClientNumber == number && p.ClientId != clientId select 1).Any();
            }
        }
        public static bool ExistCuit(string cuit, Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                return (from p in context.Client where p.ClientCuit == cuit && p.ClientId != clientId select 1).Any();
            }
        }
        public static IEnumerable<string> GetEmailList()
        {
            using (var context = new MedilabEntities())
            {
                return (from p in context.Client where !p.ClientIsDeleted && p.ClientEmailAddress != string.Empty select p.ClientEmailAddress).ToList();
            }
        }
        public static int MaxClientNumber()
        {
            using (var context = new MedilabEntities())
            {
                try
                {
                    return (from c in context.Client select c.ClientNumber).Max();
                }
                catch (InvalidOperationException)
                {
                    return 0;
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion
        /// <summary>
        /// This method will return all the clients with pending 
        /// items to be billed without taking into consideration its IVA condition  
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ListItemDto<Guid>> GetClientsWithPendingItems()
        {
            using (var context = new MedilabEntities())
            {
                const int completedItemStatus = (int)Utils.ClinicalExamStatus.Realizada;
                var clientList = (from item in context.MedicalHistoryPractice
                                    where item.Status >= completedItemStatus &&
                                          item.InvoiceId == null
                                    orderby item.MedicalHistory.PatiendId, item.GroupId
                                  select new { item.MedicalHistory.Client.ClientId, item.MedicalHistory.Client.ClientName, item.MedicalHistory.Client.ClientNumber}).ToList();
                
                var listToFilter =            
                clientList.Select(client => new ClientListItemDto
                {
                    Id = client.ClientId,
                    Value = client.ClientName,
                    Number = client.ClientNumber
                }).ToList();


                var filteredList = new List<ClientListItemDto>();
                foreach(var item in listToFilter.Where(x=>!filteredList.Any(b=>x.Id == b.Id)))
                {
                    filteredList.Add(item);  
                }

                return filteredList.OrderBy(x => x.Value);
                                    
            }
        }

        
    }
}
