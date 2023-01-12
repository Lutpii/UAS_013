using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_013

{
    class Node
    {
        public int Id;
        public string NamaPelanggan;
        public string JenisKelamin;
        public int NoHp;
        public Node next;
    }

    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void insert()
        {
            int id, np;
            string nm, jk;
            Console.Write("\nMasukkan Id Pelanggan : ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Pelanggan : ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan No HP : ");
            np = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Jenis Kelamin : ");
            jk = Console.ReadLine();

            Node newnode = new Node();

            newnode.Id = id;
            newnode.NamaPelanggan = nm;
            newnode.JenisKelamin = jk;
            newnode.NoHp = np;

            if (START == null || id <= START.Id)
            {
                if ((START != null) && (id == START.Id))
                {
                    Console.WriteLine("Id Pelanggan sudah terpakai");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (id >= current.Id))
            {
                if (id == current.Id)
                {
                    Console.WriteLine("\nId Pelanggan sudah terpakai");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(string jk, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (jk != current.NamaPelanggan))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data Pelanggan : \n");
                Console.Write("Id Pelanggan" + "   " + "Nama Pelanggan" + "    " + "No HP Pelanggan" + "   " + "Jenis Kelamin Pelanggan" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.Id + "             " + currentNode.NamaPelanggan + "              " + currentNode.NoHp + "              " + currentNode.JenisKelamin + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Masukkan List Nama Pelanggan");
                    Console.WriteLine("2. Melihat semua List Nama Pelanggan");
                    Console.WriteLine("3. Cari Data Pelanggan");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nMasukkan pilihan anda (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Data dari Nama Pelanggan yang ingin dicari : ");
                                string jks = Convert.ToString(Console.ReadLine());
                                if (obj.search(jks, ref previous, ref current) == false)
                                    Console.WriteLine("\nList tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan");
                                    Console.WriteLine("\nId Pelanggan: " + current.Id);
                                    Console.WriteLine("\nNama Pelanggan: " + current.NamaPelanggan);
                                    Console.WriteLine("\nJenis Kelamin: " + current.JenisKelamin);
                                    Console.WriteLine("\nNo HP : " + current.NoHp);
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nKETIK ANGKA 1-4");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nMohon cek kembali");
                }
            }
        }
    }
}

//2. Singly Linked List karena lebih mudah menscan, dan jika menscan langsung mencari datanya(Tidak memindah mindah data). Tidak ada batasan seperti menggunakan Array
//3. Rear, Front
//4. Array jika tidak kita mendeklarasikan penyimpanan data 5 tetapi kita menginput datanya 3 maka sisa data itu sia sia, karena array ini akan memakan memori meskipun datanya tidak ada.
//   Akan tetapi berbeda dengan linked list, linked list ini kita bisa memasukan data dan menyimpan dengan tanpa batas(Jika memori anda cukup) dan tidak ada mendeklarasi seperti array
//5. a. 10,30  5,15 10,15  20,32 20,28
//   b. Menggunakan metode Inorder 5,10,10,12,15,16,18,15,20,20,20,25,28,20,30,32