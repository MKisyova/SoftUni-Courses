using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void AddMethodShouldAddUniqueTransactionsToTheRecord()
        {
            //Arrange
            ITransaction transaction = new Transaction();

            //Act
            chainblock.Add(transaction);

            //Assert
            int expectedCount = 1;

            Assert.IsTrue(chainblock.Contains(transaction));
            Assert.AreEqual(expectedCount, chainblock.Count);

        }

        [Test]
        public void AddMethodShouldAddOnlyUniqueTransactionsToTheRecord()
        {
            ITransaction transaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction doublicateTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            chainblock.Add(transaction);
            chainblock.Add(doublicateTransaction);

            int expectedCount = 1;

            Assert.IsTrue(chainblock.Contains(transaction));
            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldChangeTransactionStatus()
        {
            int id = 12345678;

            ITransaction transaction = new Transaction
            {
                Id = id,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(id, TransactionStatus.Aborted);

            var expectedTransactionStatus = TransactionStatus.Aborted;

            Assert.AreEqual(expectedTransactionStatus, transaction.Status);
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldThrowExceptionForInvalidTransaction()
        {
            ITransaction transaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            chainblock.Add(transaction);

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(12345, TransactionStatus.Aborted));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldRemoveTransactionByGivenId()
        {
            int id = 12345678;

            ITransaction transaction = new Transaction
            {
                Id = id,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction anotherTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            chainblock.Add(transaction);
            chainblock.Add(anotherTransaction);

            chainblock.RemoveTransactionById(id);

            int expectedCount = 1;
            bool exists = chainblock.Contains(id);

            Assert.AreEqual(expectedCount, chainblock.Count);
            Assert.IsFalse(exists);
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldThrowExceptionForInvalidTransaction()
        {
            ITransaction transaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(12345));
        }

        [Test]
        public void GetByIdMethodShouldReturnTransactionWithTheGivenId()
        {
            int id = 12345678;

            ITransaction transaction = new Transaction
            {
                Id = id,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            chainblock.Add(transaction);

            Assert.AreEqual(transaction, chainblock.GetById(id));
        }

        [Test]
        public void GetByIdMethodMethodShouldThrowExceptionForInvalidTransactionId()
        {
            ITransaction transaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(12345));
        }

        [Test]
        public void GetByTransactionStatusMethodShouldReturnAllTransactionsWithTheGivenStatus()
        {

            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Successfull,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var actualResult = chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            var expectedResult = new List<ITransaction>();

            expectedResult.Add(secondTransaction);
            expectedResult.Add(firstTransaction);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusMethodShouldThrowExceptionWhenNoTransactionExistsWithTheGivenStatus()
        {

            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldReturnAllSendersWithTheGivenStatus()
        {
            for (int i = 0; i < 50; i++)
            {
                var status = TransactionStatus.Successfull;
                string sender = $"Person{i}";

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Aborted;
                }

                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                }

                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }

                if (i % 8 == 0)
                {
                    sender = "Ivan";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = status,
                    From = sender,
                    To = $"Person{i + 1}",
                    Amount = i + 10
                };

                chainblock.Add(transaction);
            }

            var filterStatus = TransactionStatus.Successfull;

            var actualResult = chainblock.GetAllSendersWithTransactionStatus(filterStatus);

            List<string> expectedResult = chainblock
                .Where(x => x.Status == filterStatus)
                .OrderBy(x => x.Amount)
                .Select(x => x.From)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldThrowExceptionWhenNoTransactionExistsWithTheGivenStatus()
        {

            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() 
                => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldReturnAllReceiversWithTheGivenStatus()
        {
            for (int i = 0; i < 50; i++)
            {
                var status = TransactionStatus.Successfull;
                string receiver = $"Person{i}";

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Aborted;
                }

                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                }

                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }

                if (i % 8 == 0)
                {
                    receiver = "Ivan";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = status,
                    From = $"Person{i + 1}",
                    To = receiver,
                    Amount = i + 10
                };

                chainblock.Add(transaction);
            }

            var filterStatus = TransactionStatus.Successfull;

            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(filterStatus);

            List<string> expectedResult = chainblock
                .Where(x => x.Status == filterStatus)
                .OrderBy(x => x.Amount)
                .Select(x => x.To)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldThrowExceptionWhenNoTransactionExistsWithTheGivenStatus()
        {

            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() 
                => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodShouldReturnAllTransactionsOrderedByAmountThenById()
        {
            for (int i = 0; i < 50; i++)
            {
                double amount = 100;

                if (i % 2 == 0)
                {
                    amount += 100;
                }

                else if (i % 3 == 0)
                {
                    amount += 200;
                }

                else if (i % 5 == 0)
                {
                    amount += 300;
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = $"Person{i}",
                    To = $"Person{i + 1}",
                    Amount = i + 10
                };

                chainblock.Add(transaction);
            }

            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById();

            List<ITransaction> expectedResult = chainblock
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldReturnAllTransactionsByTheGivenSenderOrderedByDescendingAmount()
        {
            for (int i = 0; i < 50; i++)
            {
                string sender = $"Person{i}";

                if (i % 2 == 0)
                {
                    sender = "Ivan";
                }

                else if (i % 3 == 0)
                {
                    sender = "Maria";
                }

                else if (i % 5 == 0)
                {
                    sender = "Stoyan";
                }

                if (i % 8 == 0)
                {
                    sender = "Nevena";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = sender,
                    To = $"Person{i + 1}",
                    Amount = i + 10
                };

                chainblock.Add(transaction);
            }

            string senderToFilter = "Maria";

            var actualResult = chainblock.GetBySenderOrderedByAmountDescending(senderToFilter);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.From == senderToFilter)
                .OrderByDescending(x => x.Amount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldThrowExceptionWhenNoTransactionsExistsByTheGivenSender()
        {
            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Nevena"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldReturnAllTransactionsByTheGivenReceiverOrderedByAmountThenById()
        {
            for (int i = 0; i < 50; i++)
            {
                string receiver = $"Person{i}";

                if (i % 2 == 0)
                {
                    receiver = "Ivan";
                }

                else if (i % 3 == 0)
                {
                    receiver = "Maria";
                }

                else if (i % 5 == 0)
                {
                    receiver = "Stoyan";
                }

                if (i % 8 == 0)
                {
                    receiver = "Nevena";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = $"Person{i + 1}",
                    To = receiver,
                    Amount = 1000 - i
                };

                chainblock.Add(transaction);
            }

            string receiverToFilter = "Maria";

           var actualResult = chainblock.GetByReceiverOrderedByAmountThenById(receiverToFilter);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.To == receiverToFilter)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowExceptionWhenNoTransactionsExistsByTheGivenReceiver()
        {
            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 10
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 100
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 50
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Nevena"));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodShouldReturnAllTransactionsByTheGivenStatusAndAmountLessOrEqualToAMaximumAllowedAmount()
        {
            for (int i = 0; i < 50; i++)
            {
                var status = TransactionStatus.Successfull;

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Aborted;
                }

                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                }

                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }


                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = status,
                    From = $"Person{i + 1}",
                    To = $"Person{i}",
                    Amount = i + 1000
                };

                chainblock.Add(transaction);
            }

            var filterStatus = TransactionStatus.Successfull;
            var maximumAmount = 1030;

            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(filterStatus, maximumAmount);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.Status == filterStatus && x.Amount <= maximumAmount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodShouldReturnEmptyCollectionWhenNoTransactionExistsWithTheGivenStatusAndAmountLessOrEqualToAMaximumAllowedAmount()
        {

            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 1000
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 2000
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Successfull,
                From = "Stoyan",
                To = "Ivan",
                Amount = 3000
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var maximumAmount = 1000;

            Assert.IsEmpty(chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, maximumAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldReturnAllTransactionsByTheGivenSenderAndAmountBiggerThanGivenAmountOrderedByDescendingAmount()
        {
            for (int i = 0; i < 50; i++)
            {
                string sender = $"Person{i}";

                if (i % 2 == 0)
                {
                    sender = "Ivan";
                }

                else if (i % 3 == 0)
                {
                    sender = "Maria";
                }

                else if (i % 5 == 0)
                {
                    sender = "Stoyan";
                }

                if (i % 8 == 0)
                {
                    sender = "Nevena";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = sender,
                    To = $"Person{i + 1}",
                    Amount = i + 1000
                };

                chainblock.Add(transaction);
            }

            string senderToFilter = "Maria";
            var minimumAmount = 1030;

            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending(senderToFilter, minimumAmount);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.From == senderToFilter && x.Amount > minimumAmount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldThrowExceptionWhenNoTransactionsExistsByTheGivenSenderAndAmountBiggerThanGivenAmount()
        {
            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 1000
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 2000
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 3000
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var minimumAmount = 2500;

            Assert.Throws<InvalidOperationException>(() 
                => chainblock.GetBySenderAndMinimumAmountDescending("Maria", minimumAmount));
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldReturnAllTransactionsByTheGivenReceiverAndAmountInGivenRangeOrderedByDescendingAmountThenByI()
        {
            for (int i = 0; i < 50; i++)
            {
                string receiver = $"Person{i}";

                if (i % 2 == 0)
                {
                    receiver = "Ivan";
                }

                else if (i % 3 == 0)
                {
                    receiver = "Maria";
                }

                else if (i % 5 == 0)
                {
                    receiver = "Stoyan";
                }

                if (i % 8 == 0)
                {
                    receiver = "Nevena";
                }

                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = $"Person{i + 1}",
                    To = receiver,
                    Amount = i + 1000
                };

                chainblock.Add(transaction);
            }

            string receiverToFilter = "Maria";
            var minimumAmount = 1010;
            var maximumAmount = 1040;

            var actualResult = chainblock.GetByReceiverAndAmountRange(receiverToFilter, minimumAmount, maximumAmount);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.To == receiverToFilter && x.Amount >= minimumAmount && x.Amount < maximumAmount)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldThrowExceptionWhenNoTransactionsExistsByTheGivenReceiverAndAmountInGivenRange()
        {
            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 1000
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 2000
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 3000
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var minimumAmount = 2100;
            var maximumAmount = 3000;

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Maria", minimumAmount, maximumAmount));
        }

        [Test]
        public void GetAllInAmountRangeMethodShouldReturnAllTransactionsWithinGivenRange()
        {
            for (int i = 0; i < 50; i++)
            {
                ITransaction transaction = new Transaction
                {
                    Id = i,
                    Status = TransactionStatus.Successfull,
                    From = $"Person{i}",
                    To = $"Person{i + 1}",
                    Amount = i + 1000
                };

                chainblock.Add(transaction);
            }

            var minimumAmount = 1010;
            var maximumAmount = 1040;

            var actualResult = chainblock.GetAllInAmountRange(minimumAmount, maximumAmount);

            List<ITransaction> expectedResult = chainblock
                .Where(x => x.Amount >= minimumAmount && x.Amount <= maximumAmount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllInAmountRangeMethodShouldShouldReturnEmptyCollectionWhenNoTransactionExistsWithinGivenRange()
        {
            ITransaction firstTransaction = new Transaction
            {
                Id = 12345678,
                Status = TransactionStatus.Unauthorized,
                From = "Ivan",
                To = "Maria",
                Amount = 1000
            };

            ITransaction secondTransaction = new Transaction
            {
                Id = 5677889,
                Status = TransactionStatus.Successfull,
                From = "Maria",
                To = "Ivan",
                Amount = 2000
            };

            ITransaction thirdTransaction = new Transaction
            {
                Id = 000000,
                Status = TransactionStatus.Aborted,
                From = "Stoyan",
                To = "Ivan",
                Amount = 3000
            };

            chainblock.Add(firstTransaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var minimumAmount = 4000;
            var maximumAmount = 5000;

            Assert.IsEmpty(chainblock.GetAllInAmountRange(minimumAmount, maximumAmount));
        }

    }
}
