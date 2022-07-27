using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }
        public int Count 
            => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                return;
            }

            this.transactions.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException("Transaction with this id doesn't exist");
            }

            this.transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
            => this.transactions.ContainsKey(tx.Id);

        public bool Contains(int id)
            => this.transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            List<ITransaction> transactionsInAmountRange = this.transactions
                .Values
                .Where(x => x.Amount >= lo && x.Amount <= hi)
                .ToList();

            if (transactionsInAmountRange.Count == 0)
            {
                transactionsInAmountRange = new List<ITransaction>();
            }

            return transactionsInAmountRange;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => this.transactions
            .Values
            .OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id)
            .ToList();

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> receivers = this.transactions
                .Values
                .Where(x => x.Status == status)
                .OrderBy(x => x.Amount)
                .Select(x => x.To)
                .ToList();

            if (receivers.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given status");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = this.transactions
                .Values
                .Where(x => x.Status == status)
                .OrderBy(x => x.Amount)
                .Select(x => x.From)
                .ToList();

            if (senders.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given status");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("Transaction with the given id doesn't exist");
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> transactionsByReceiverAndAmountRange = this.transactions
                .Values
                .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            if (transactionsByReceiverAndAmountRange.Count == 0)
            {
                throw new InvalidOperationException
                    ("There are no transactions with the given receiver within the given amount range");
            }

            return transactionsByReceiverAndAmountRange;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> transactionsByReceiver = this.transactions
                .Values
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            if (transactionsByReceiver.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given receiver");
            }

            return transactionsByReceiver;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> transactionsBySenderAndMinimumAmountDescending = this.transactions
                .Values
                .Where(x => x.From == sender && x.Amount > amount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (transactionsBySenderAndMinimumAmountDescending.Count == 0)
            {
                throw new InvalidOperationException
                    ("There are no transactions with the given sender with amount bigger than given amount");
            }

            return transactionsBySenderAndMinimumAmountDescending;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> transactionsBySender = this.transactions
                .Values
                .Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (transactionsBySender.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given sender");
            }

            return transactionsBySender;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactionsByStatus = this.transactions
                .Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (transactionsByStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given status");
            }

            return transactionsByStatus;

        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> transactionsByStatusAndAmount = this.transactions
                .Values
                .Where(x => x.Status == status && x.Amount <= amount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (transactionsByStatusAndAmount.Count == 0)
            {
                transactionsByStatusAndAmount = new List<ITransaction>();
            }

            return transactionsByStatusAndAmount;
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("Transaction with the given id doesn't exist");
            }

            this.transactions.Remove(id);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
