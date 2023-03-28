using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Collections.Generic;
using FNOWebServiceWrapper.OrganizationAdministration;
using FNOWebServiceWrapper.EntitlementOrderService;
using FNOWebServiceWrapper.UserOrgHierarchyService;
using SimpleQueryType = FNOWebServiceWrapper.EntitlementOrderService.SimpleQueryType;
using SymetriRentalApp;

namespace WinFormsApp1
{
    internal class Logging
    {
        private string GenerateErrorMessage(failedAddEntitlementLineItemDataType[] failedlist, EntitlementOrderService.StatusInfoType statusInfo, string startText)
        {
            string returnString = startText;
            returnString += Environment.NewLine + "Reason:" + Environment.NewLine + statusInfo.reason;

            returnString += Environment.NewLine + Environment.NewLine + "Detailed reason:";
            foreach (failedAddEntitlementLineItemDataType failedItem in failedlist)
            {
                returnString += Environment.NewLine + failedItem.reason;
            }
            return returnString;
        }

        private string GenerateErrorMessage(failedLineItemStateDataType[] failedlist, EntitlementOrderService.StatusInfoType statusInfo, string startText)
        {
            string returnString = startText;
            returnString += Environment.NewLine + "Reason:" + Environment.NewLine + statusInfo.reason;

            returnString += Environment.NewLine + Environment.NewLine + "Detailed reason:";
            foreach (failedLineItemStateDataType failedItem in failedlist)
            {
                returnString += Environment.NewLine + failedItem.reason;
            }
            return returnString;
        }

        private string GenerateErrorMessage(failedSimpleEntitlementDataType[] failedlist, EntitlementOrderService.StatusInfoType statusInfo, string startText)
        {
            string returnString = startText;
            returnString += Environment.NewLine + "Reason:" + Environment.NewLine + statusInfo.reason;

            returnString += Environment.NewLine + Environment.NewLine + "Detailed reason:";
            foreach (failedSimpleEntitlementDataType failedItem in failedlist)
            {
                returnString += Environment.NewLine + failedItem.reason;
            }
            return returnString;
        }

        private string GenerateErrorMessage(failedEntitlementStateDataType[] failedlist, EntitlementOrderService.StatusInfoType statusInfo, string startText)
        {
            string returnString = startText;
            returnString += Environment.NewLine + "Reason:" + Environment.NewLine + statusInfo.reason;

            returnString += Environment.NewLine + Environment.NewLine + "Detailed reason:";
            foreach (failedEntitlementStateDataType failedItem in failedlist)
            {
                returnString += Environment.NewLine + failedItem.reason;
            }
            return returnString;
        }

        private string CreateLog_Start()
        {
            string logString = "";
            logString = NEWLINE + NEWLINE;
            logString += STARS + NEWLINE + STARS + NEWLINE;

            return logString;
        }

        private string CreateLog_CommandName_Date(string commandName)
        {
            string logString = "";
            logString += "CommandName: " + commandName + NEWLINE;
            logString += "Date: " + DateTime.Now.ToString() + NEWLINE;

            return logString;
        }

        private string CreateLog_ReturnResultParameters(Results returnResult)
        {
            string logString = "";
            logString += "Successful: " + returnResult.Successful.ToString() + NEWLINE;
            logString += "StatusDescription: " + returnResult.StatusDescription + NEWLINE;
            logString += "ErrorPosition: " + returnResult.ErrorPosition + NEWLINE;
            logString += "EntilementID: " + returnResult.EntilementID + NEWLINE;
            logString += "LineItemID: " + returnResult.LineItemID + NEWLINE;
            logString += NEWLINE;

            return logString;
        }

        private string CreateLog_InParameters(string inParameters)
        {
            string logString = "";
            logString += "In Paramaters:" + NEWLINE + THREE_SPACES;
            logString += inParameters.Replace(NEWLINE, NEWLINE + THREE_SPACES) + NEWLINE;

            return logString;
        }

        private string CreateLog_End()
        {
            string logString = "";
            logString += STARS;

            return logString;
        }

        private void WriteLog(string commandName, Results returnResult, string inParameters)
        {
            string logString = "";
            logString += CreateLog_Start();
            logString += CreateLog_CommandName_Date(commandName);
            logString += CreateLog_ReturnResultParameters(returnResult);
            logString += CreateLog_InParameters(inParameters);
            logString += CreateLog_End();

            Logging logObject = new Logging();
            logObject.WriteToLog(LOG_PATH, LOG_FILE_NAME, logString);
        }

        private void WriteLog(string commandName, Results[] returnResultArray, string inParameters)
        {
            string logString = "";
            logString += CreateLog_Start();
            logString += CreateLog_CommandName_Date(commandName);
            foreach (Results res in returnResultArray)
            {
                logString += CreateLog_ReturnResultParameters(res);
            }
            logString += CreateLog_InParameters(inParameters);
            logString += CreateLog_End();

            Logging logObject = new Logging();
            logObject.WriteToLog(LOG_PATH, LOG_FILE_NAME, logString);

        }

        internal void WriteSimpleLogString(string text)
        {
            string logString = "";
            logString = NEWLINE + NEWLINE;
            logString += STARS + NEWLINE + STARS + NEWLINE;
            logString += "Date: " + DateTime.Now.ToString() + NEWLINE;
            logString += text;
            logString += STARS;
            Logging logObject = new Logging();
            logObject.WriteToLog(LOG_PATH, LOG_FILE_NAME, logString);
        }

    }
}
