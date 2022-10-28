using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName,string emailAddress,decimal moneyToInvest,string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get { return Portfolio.Count; } }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization>10000m&&MoneyToInvest>=stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest-=stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Exists(x => x.CompanyName.Equals(companyName)))
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                Stock stock = Portfolio.FirstOrDefault(x=>x.CompanyName.Equals(companyName));
                if (stock.PricePerShare > sellPrice)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    Portfolio.RemoveAll(x=>x.CompanyName == companyName);
                    return $"{companyName} was sold.";
                }
               
            }
        }
        public Stock FindStock(string companyName)
        {
            if (Portfolio.Exists(x => x.CompanyName.Equals(companyName)))
            {
                return Portfolio.FirstOrDefault(x => x.CompanyName.Equals(companyName));
            }
            else
            {
                return null;
            }
        }
        public Stock FindBiggestCompany()
        {
            if (!Portfolio.Any())
            {
                return null;
            }
            else
            {
                decimal maxPrice = decimal.MinValue;
                foreach (var company in Portfolio)
                {
                    if (company.MarketCapitalization > maxPrice)
                    {
                        maxPrice = company.MarketCapitalization;
                    }
                }
                return Portfolio.FirstOrDefault(x => x.MarketCapitalization == maxPrice);
            }
        }
        public string InvestorInformation()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                info.AppendLine(item.ToString());
            }
            return info.ToString().Trim();
        }

    }
}
