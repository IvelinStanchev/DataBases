using ATM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_MoneyTransactions
{
    class MoneyTransactions
    {
        static void Main()
        {
            ATMEntities context = new ATMEntities();

            string cardPIN = "1512";
            string cardNumber = "1242612412";
            decimal moneyToBeTransfered = 200;

            TransferMoney(cardNumber, cardPIN, moneyToBeTransfered, context);
        }

        private static void CommitCurrentLog(string cardNumber, DateTime transactionDate, decimal ammount, ATMEntities context)
        {
            using (context)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        TransactionsHistory newTransactionLog = new TransactionsHistory()
                        {
                            CardNumber = cardNumber,
                            TransactionDate = transactionDate,
                            Ammount = ammount
                        };

                        context.TransactionsHistories.Add(newTransactionLog);

                        context.SaveChanges();

                        dbContextTransaction.Commit();

                        Console.WriteLine("The log has been commited!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        private static void TransferMoney(string cardNumber, string cardPIN, decimal moneyToBeTransfered, ATMEntities context)
        {
            using (context)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    try
                    {
                        var cardId = context.CardAccounts.Where(ca => ca.CardNumber == cardNumber && ca.CardPIN == cardPIN);
                        if (cardId.Count() < 1)
                        {
                            throw new ArgumentException("The provided card data is invalid. The cardPIN and cardNumber do not match!");
                        }

                        var account = cardId.FirstOrDefault();

                        if (moneyToBeTransfered > account.CardCash)
                        {
                            throw new ArgumentException("The account does not have enough money!");
                        }

                        account.CardCash -= moneyToBeTransfered;

                        context.SaveChanges();

                        dbContextTransaction.Commit();

                        Console.WriteLine("The machine successfuly withdrawed {0}$.\nYour current balance: {1}$", 
                            moneyToBeTransfered, account.CardCash);

                        CommitCurrentLog(cardNumber, DateTime.Now, moneyToBeTransfered, context);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
