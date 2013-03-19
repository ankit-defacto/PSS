using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    public class ClientCardInfoGateway: GatewayBase,iClientCardInfoGateway
    {
        public ClientCardInfo Insert(ClientCardInfo entity)
        {
            //@@NEW - changed return type to entity type.
            try
            {
                ClientCardInfo daClientCardInfo = new ClientCardInfo();
                using (PSS2012DataContext context = this.DataContext)
                {
                    daClientCardInfo = (
                        from items in context.ClientCardInfos
                        where items.ClientGuid == entity.ClientGuid
                        select items).SingleOrDefault();

                    if (daClientCardInfo != null)
                        return daClientCardInfo;

                    entity.ClientCardGuid = Guid.NewGuid();
                    context.ClientCardInfos.InsertOnSubmit(entity);
                    context.SubmitChanges();
                }

                //@@NEW - returning full entity.
                return entity;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw this.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ClientCardInfo entity)
        {
            try
            {
                using (PSS2012DataContext context = this.DataContext)
                {
                    ClientCardInfo clientcardToUpdate = context.ClientCardInfos.Single(c => c.ClientCardGuid == entity.ClientCardGuid);

                    clientcardToUpdate.CardHolderNameOnCard = entity.CardHolderNameOnCard;
                    clientcardToUpdate.Cardtype = entity.Cardtype;
                    clientcardToUpdate.CardNumber = entity.CardNumber;
                    clientcardToUpdate.CvvNumber = entity.CvvNumber;
                    clientcardToUpdate.ExpMonth = entity.ExpMonth;
                    clientcardToUpdate.ExpYear = entity.ExpYear;

                    // Perform the update.
                    context.SubmitChanges();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw this.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientCardInfo GetByClientGuid(System.Guid clientGuid)
        {
            if (Guid.Empty == clientGuid)
            { return new ClientCardInfo(); }

            try
            {
                ClientCardInfo daClientCardInfo = new ClientCardInfo();
                using (PSS2012DataContext context = this.DataContext)
                {
                    daClientCardInfo = (
                        from items in context.ClientCardInfos
                        where items.ClientGuid == clientGuid
                        select items).SingleOrDefault();
                }
                return daClientCardInfo;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw this.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Private Handle Exception Methods
        private Exception HandleSqlException(System.Data.SqlClient.SqlException ex)
        {
            if (ex.Message.Contains("An error has occurred while establishing a connection to the server.  When connecting to SQL Server 2005, this failure may be caused by the fact that under the default settings SQL Server does not allow remote connections."))
            {
                return new Exception("Could not establish a connection to SQL Server. See inner exception for more details. Perhaps Windows Firewall has blocked the connection to SQL Server. Check online resources to find out how to allow port exceptions.", ex);
            }
            else if (ex.Message.Contains("Invalid object name 'dbo.ListingType'"))
            {
                return new TableDoesNotExistException("PSS2012", "ListingType", ex);
            }
            else if (ex.Message.Contains("Invalid column name"))
            {
                return new ColumnDoesNotExistException("PSS2012", "ListingType", ex);
            }
            else if (ex.Message.Contains("String or binary data would be truncated"))
            {
                return new DataAccessException("String or number is too long or too big for the database.", ex);
            }
            else if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                Regex errorRx = new Regex("The DELETE statement conflicted with the REFERENCE constraint \"(?<constraint>[\\x20-\\x7E-[\"]]{1,})\". The conflict occurred in database \"(?<db>[\\x20-\\x7E-[\"]]{1,50})\", table \"dbo.(?<jtn>[\\x20-\\x7E-[\"]]{1,50})\"");
                Match errorMatch = errorRx.Match(ex.Message);
                if (errorMatch.Success)
                {
                    return new RowReferencedElsewhereException(errorMatch.Groups["db"].Value, "ListingType", errorMatch.Groups["jtn"].Value, ex);
                }
                else
                { return ex; }
            }
            else
            {
                return ex;
            }
        }
        #endregion




    }
}
