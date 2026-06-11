# Data Structures Project: Binary Search Tree, Hash Table, Heap and Sorting in C#

## English

This repository contains a C# console application that processes Aegean Sea fish species data using several core data structures and algorithms.

The project reads fish descriptions from a text file, separates the data into fish records, extracts words from each description, and organizes these words inside binary search trees. It also uses hash table logic for fast access and update operations, a max heap for priority-based extraction, and sorting algorithms to compare execution time.

The project was developed to understand how different data structures affect data organization, searching, updating, priority handling, and algorithm performance in a practical data processing scenario.

---

## Project Overview

The application works with a text-based fish dataset. Each fish has a name and a description. The program parses this data and performs multiple operations using different data structures.

Main operations include:

* Creating word trees for fish descriptions
* Listing fish records and their extracted words
* Calculating tree depth and node count
* Building a balanced binary search tree from fish names
* Searching fish names by letter range
* Storing fish records in a hash table
* Updating fish information through hash table access
* Inserting fish records into a max heap
* Extracting the first three records from the max heap
* Comparing Bubble Sort and Shell Sort execution times

---

## Main Features

### Fish Data Processing with Binary Search Trees

Each fish description is split into individual words. These words are inserted into a binary search tree in alphabetical order.

For each fish record, the program can:

* Store extracted words in a tree structure
* List words using in-order traversal
* Calculate the depth of the word tree
* Count the number of nodes in the tree
* Compare the existing tree depth with a balanced tree depth

This part helped me understand how binary search trees organize text-based data and how tree structure affects traversal and depth.

---

### Balanced Tree Construction

The project also creates a balanced binary search tree using fish names.

The fish names are first sorted alphabetically. Then, the middle element is selected recursively as the root node, while the remaining elements are placed into the left and right subtrees.

This shows how recursive logic can be used to build a more balanced tree structure and reduce unnecessary depth.

---

### Search by Letter Range

The application allows fish names to be listed based on a starting and ending letter.

This feature demonstrates how ordered data can be filtered and searched using simple comparison logic.

---

### Hash Table Usage

Fish records are stored in a hash table structure where the fish name is used as the key and the fish object is used as the value.

This allows fast access to a selected fish record. The program also supports updating a fish description by finding the fish through the hash table, clearing the old word tree, and rebuilding it with the new input.

This part helped me practice key-value data access and understand why hash tables are useful for lookup and update operations.

---

### Max Heap Implementation

The project includes a custom max heap structure for fish records.

Fish objects are inserted into the heap and ordered according to their names. The application extracts the first three records from the heap using the ExtractMax operation.

This part demonstrates priority-based data organization and how heap structures maintain their order after insertion and extraction operations.

---

### Sorting Algorithm Comparison

The project implements and compares two sorting algorithms:

* Bubble Sort
* Shell Sort

A random integer array is generated and both algorithms are executed repeatedly. Their execution times are measured using Stopwatch.

This comparison shows the practical performance difference between a simple quadratic sorting algorithm and a more optimized gap-based sorting algorithm.

---

## Data Structures and Algorithms Used

* Binary Search Tree
* Balanced Binary Search Tree
* Hash Table / Dictionary
* Max Heap
* In-order Traversal
* Recursive Tree Construction
* Bubble Sort
* Shell Sort
* File Reading
* Performance Measurement with Stopwatch

---

## Technologies Used

* C#
* .NET Framework 4.7.2
* Visual Studio 2022
* Console Application
* Object-Oriented Programming
* File I/O

---

## What I Implemented and Learned

In this project, I worked on how different data structures can be applied to the same dataset for different purposes.

I used binary search trees to organize extracted words from fish descriptions and practiced tree traversal, depth calculation, and node counting. I also implemented balanced tree construction using recursion, which helped me understand how tree shape affects efficiency.

By using a hash table, I practiced fast key-based access and update operations. This made the difference between sequential searching and direct lookup clearer.

With the max heap implementation, I practiced priority-based data handling and learned how insertion, extraction, and heapify operations maintain the heap property.

Finally, by implementing Bubble Sort and Shell Sort and measuring their execution times, I observed how algorithm choice affects runtime performance even when the input data is the same.

Main topics I practiced:

* Parsing text data from an external file
* Creating object-based data models
* Building and traversing binary search trees
* Calculating tree depth and node count
* Creating balanced trees with recursion
* Using hash tables for fast access and update
* Implementing a custom max heap
* Comparing sorting algorithms through measured execution time
* Applying object-oriented programming principles in C#

---

# C# ile Veri Yapıları Projesi: İkili Arama Ağacı, Hash Table, Heap ve Sıralama

## Türkçe

Bu repository, Ege Denizi balık türlerine ait verileri farklı veri yapıları ve algoritmalar kullanarak işleyen bir C# konsol uygulamasını içermektedir.

Proje, balık açıklamalarını bir metin dosyasından okur, verileri balık kayıtlarına ayırır, açıklamalardaki kelimeleri çıkarır ve bu kelimeleri ikili arama ağaçları içinde organize eder. Ayrıca hızlı erişim ve güncelleme işlemleri için hash table mantığı, öncelik tabanlı çıkarma işlemleri için max heap yapısı ve çalışma süresi karşılaştırması için sıralama algoritmaları kullanılmıştır.

Bu proje, farklı veri yapılarının veri organizasyonu, arama, güncelleme, öncelik yönetimi ve algoritma performansı üzerindeki etkisini pratik bir veri işleme senaryosu üzerinden anlamak için geliştirilmiştir.

---

## Proje Özeti

Uygulama, metin tabanlı bir balık veri seti üzerinde çalışır. Her balığın bir adı ve açıklaması bulunur. Program bu veriyi ayrıştırır ve farklı veri yapıları kullanarak çeşitli işlemler gerçekleştirir.

Başlıca işlemler:

* Balık açıklamalarındaki kelimelerden ağaç yapıları oluşturma
* Balık kayıtlarını ve çıkarılan kelimeleri listeleme
* Ağaç derinliği ve düğüm sayısı hesaplama
* Balık isimlerinden dengeli ikili arama ağacı oluşturma
* Harf aralığına göre balık ismi arama/listeleme
* Balık kayıtlarını hash table içinde saklama
* Hash table üzerinden balık bilgisini güncelleme
* Balık kayıtlarını max heap yapısına ekleme
* Max heap üzerinden ilk üç kaydı çıkarma
* Bubble Sort ve Shell Sort çalışma sürelerini karşılaştırma

---

## Temel Özellikler

### Binary Search Tree ile Balık Verisi İşleme

Her balığın açıklaması kelimelere ayrılır. Bu kelimeler alfabetik sıraya göre ikili arama ağacına eklenir.

Her balık kaydı için program şunları yapabilir:

* Açıklamadan çıkarılan kelimeleri ağaç yapısında saklama
* In-order traversal ile kelimeleri sıralı listeleme
* Kelime ağacının derinliğini hesaplama
* Ağaçtaki düğüm sayısını bulma
* Mevcut ağaç derinliği ile dengeli ağaç derinliğini karşılaştırma

Bu bölüm, ikili arama ağaçlarının metin tabanlı verileri nasıl organize ettiğini ve ağaç yapısının derinlik/traversal üzerinde nasıl etkili olduğunu anlamamı sağladı.

---

### Dengeli Ağaç Oluşturma

Projede balık isimleri kullanılarak dengeli bir ikili arama ağacı da oluşturulur.

Balık isimleri önce alfabetik olarak sıralanır. Daha sonra orta eleman kök düğüm olarak seçilir ve kalan elemanlar rekürsif olarak sol ve sağ alt ağaçlara yerleştirilir.

Bu yapı, rekürsif mantıkla daha dengeli bir ağaç oluşturmayı ve gereksiz ağaç derinliğini azaltmayı gösterir.

---

### Harf Aralığına Göre Arama

Uygulama, kullanıcıdan başlangıç ve bitiş harfi alarak bu aralıkta bulunan balık isimlerini listeler.

Bu özellik, sıralı/veri karşılaştırma mantığı ile filtreleme ve arama işlemlerinin nasıl yapılabileceğini gösterir.

---

### Hash Table Kullanımı

Balık kayıtları, balık adının key ve balık nesnesinin value olduğu bir hash table yapısında saklanır.

Bu yapı sayesinde seçilen bir balık kaydına hızlı şekilde erişilebilir. Program ayrıca hash table üzerinden bulunan bir balığın açıklamasını güncelleyebilir. Güncelleme sırasında eski kelime ağacı temizlenir ve yeni girilen açıklamadan oluşturulan kelimelerle yeniden kurulur.

Bu bölümde key-value veri erişimini ve hash table yapısının arama/güncelleme işlemlerinde neden kullanışlı olduğunu uyguladım.

---

### Max Heap Implementasyonu

Projede balık kayıtları için özel bir max heap yapısı bulunmaktadır.

Balık nesneleri heap içine eklenir ve balık adına göre sıralanır. Uygulama ExtractMax işlemiyle heap üzerinden ilk üç kaydı çıkarır.

Bu bölüm, öncelik tabanlı veri organizasyonunu ve heap yapısının ekleme/çıkarma işlemlerinden sonra düzenini nasıl koruduğunu göstermektedir.

---

### Sıralama Algoritmaları Karşılaştırması

Projede iki sıralama algoritması uygulanır ve karşılaştırılır:

* Bubble Sort
* Shell Sort

Rastgele sayılardan oluşan bir dizi üretilir ve iki algoritma aynı veri üzerinde tekrar tekrar çalıştırılır. Çalışma süreleri Stopwatch kullanılarak ölçülür.

Bu karşılaştırma, aynı veri üzerinde farklı algoritma seçimlerinin çalışma süresini nasıl etkilediğini pratik olarak göstermektedir.

---

## Kullanılan Veri Yapıları ve Algoritmalar

* Binary Search Tree
* Balanced Binary Search Tree
* Hash Table / Dictionary
* Max Heap
* In-order Traversal
* Recursive Tree Construction
* Bubble Sort
* Shell Sort
* Dosya Okuma
* Stopwatch ile Performans Ölçümü

---

## Kullanılan Teknolojiler

* C#
* .NET Framework 4.7.2
* Visual Studio 2022
* Konsol Uygulaması
* Nesne Yönelimli Programlama
* Dosya Okuma/Yazma İşlemleri

---

## Bu Projede Ne Uyguladım ve Ne Öğrendim?

Bu projede, farklı veri yapılarının aynı veri seti üzerinde farklı amaçlar için nasıl kullanılabileceğini uyguladım.

Balık açıklamalarından çıkarılan kelimeleri organize etmek için binary search tree yapısını kullandım ve tree traversal, derinlik hesaplama ve düğüm sayısı bulma işlemlerini uyguladım. Ayrıca rekürsif olarak dengeli ağaç oluşturma mantığını kullanarak ağaç yapısının verimliliği nasıl etkilediğini gördüm.

Hash table kullanarak key tabanlı hızlı erişim ve güncelleme işlemlerini uyguladım. Bu sayede sıralı arama ile doğrudan erişim arasındaki farkı daha net gördüm.

Max heap implementasyonu ile öncelik tabanlı veri yönetimi üzerinde çalıştım. Ekleme, ExtractMax ve heapify işlemlerinin heap yapısını nasıl koruduğunu uygulamalı olarak inceledim.

Son olarak Bubble Sort ve Shell Sort algoritmalarını implemente edip çalışma sürelerini ölçerek, algoritma seçiminin performans üzerindeki etkisini gözlemledim.

Bu projede pratik yaptığım ana konular:

* Harici dosyadan metin verisi okuma ve ayrıştırma
* Nesne tabanlı veri modeli oluşturma
* Binary search tree oluşturma ve dolaşma
* Ağaç derinliği ve düğüm sayısı hesaplama
* Rekürsif yöntemle dengeli ağaç oluşturma
* Hash table ile hızlı erişim ve güncelleme
* Custom max heap implementasyonu
* Sıralama algoritmalarını çalışma süresiyle karşılaştırma
* C# ile nesne yönelimli programlama prensiplerini uygulama
