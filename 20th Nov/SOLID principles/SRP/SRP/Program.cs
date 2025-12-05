using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSrp

{

    internal class SRP

    {

        static void Main(string[] args)

        {

            Invoice invoice = new Invoice();

            invoice.GenerateInvoice();

            // Process invoice (save and send email)

            invoiceprocessor processor = new invoiceprocessor();

            processor.Process(invoice);

            Console.ReadLine();

        }

        public class Invoice

        {

            public void GenerateInvoice()

            {

                Console.WriteLine("Invoice generated successfully.");

            }

        }

        public class InvoiceRepository

        {

            public void SaveToDatabase(Invoice invoice)

            {

                Console.WriteLine("Code for Save invoice into database");

            }

        }

        public class EmailService

        {

            public void SendEmail(Invoice invoice)

            {

                Console.WriteLine("Code for send invoice by mail");

            }

        }

        public class invoiceprocessor

        {

            InvoiceRepository invoiceRepository = new InvoiceRepository();

            EmailService emailService = new EmailService();

            public void Process(Invoice invoice)

            {

                invoiceRepository.SaveToDatabase(invoice);

                emailService.SendEmail(invoice);

            }

        }

    }

}

