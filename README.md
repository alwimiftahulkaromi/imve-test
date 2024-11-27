# IMVE Test

Dokumen ini berisi jawaban untuk soal-soal
1. Apa yang anda ketahui dari beberapa fitur Unity di bawah ini? (10 poin)
 - Coroutine
Semacam pengganti method biasa yang dapat menjalankan isinya berdasarkan rentang waktu tertentu. Tipenya IEnumerator, dapat diakhiri dengan “break” atau yield return null (null dapat diganti fungsi tertentu.
 - Singleton
Merupakan self static reference di dalam suatu non-static class atau script yang instance-nya dapat diakses secara global oleh script lain. 
 - Profiler
Jika yang dimaksud adalah Unity Profiler, berarti merupakan debugging tools yang digunakan untuk menampilkan data statistik seperti game performance, memory usage, audio, network, dll.
 - Render pipeline
Merupakan gabungan beberapa proses yang Unity lakukan untuk menghasilkan gambar ke layar. Mulai dari memproses game assets beserta texturenya, pencahayaan, sampai post-processing, hingga dapat dilihat oleh pengguna. Selain Built-In Render Pipeline, Unity juga memiliki render pipeline lain yaitu Universal Render Pipeline (URP) yang compatible untuk berbagai platform, juga ada High Definition Render Pipeline (HDRP) yang dapat memproses hal yang lebih kompleks seperti PBR, dan real-time global illumination.
 - Addressable asset
Semacam sistem untuk manajemen assets menggunakan grup. Aset-aset yang dimasukkan ke Addressable Assets Groups nantinya dapat diakses dan di-load untuk digunakan 
 - Occlusion culling
Proses rendering yang mengabaikan (remove) objek-objek yang tidak tampak di depan kamera.
 - Post processing
Proses untuk meningkatkan kualitas visual, seperti menambahkan color grading, bloom, blur, atau vignette.

2. Apa yang anda ketahui tentang SOLID principle? Bagaimana penerapannya di dalam game? (5 poin)
Setelah saya coba pahami, SOLID Principle merupakan prinsip dalam OOP yang dapat menjadikan program lebih modular, mudah di-scale, dan mengoptimalkan waktu pekerjaan.
 - S (Single Responsibility Principle) yang berarti setiap class hanya boleh memiliki satu tugas saja. Sehingga variable atau method yang terdapat di dalamnya harus relevan dengan tugas. Contohnya PlayerController hanya bertugas terkait mengontrol player, dan LevelManager bertugas untuk mengatur perpindahan level.
 - O (Open Closed Principle) yang berarti setiap class harus terbuka untuk penambahan (ekstensi) dan tertutup untuk perubahan (modifikasi). Salah satu cara menerapkannya yaitu dengan membuat base class. Contohnya base class Item yang berisi method atau variable tertentu (seperti itemQuantity GetItemQuantity()), yang nantinya class Sword, Bow, Potion, dll harus mengimplementasikan base class Item (public class Sword : Item).
 - L (Liskov Substitution Principle) menyatakan bahwa setiap parent class harus dapat digantikan oleh derived class-nya tanpa error. Jadi setiap derived class harus memiliki semua behaviour yang ada di parent-nya. Contoh penggunaannya seperti menggunakan behaviour parent class IPointerClickHandler ketika ingin menggunakan OnPointerClick(), dan hanya menggunakan MonoBehaviour jika hanya memerlukan method seperti Start(), Update(), dll.
 - I (Interface Segregation Principle) menyatakan setiap class hanya boleh mengimplementasikan interface yang pasti akan digunakan. Jadi ketika terdapat class yang terlalu general, mungkin perlu dipisah berdasarkan spesialisasinya sehingga tidak ada method yang redundant.
 - D (Dependency Inversion Principle) menyatakan bahwa modul high-level tidak boleh bergantung pada modul low-level. Dua-duanya harus bergantung pada abstractions. Abstraction tidak boleh bergantung pada details. Details harus bergantung pada Abstractions.

3. Menurut anda, bagaimana cara optimize game di Unity? (10 poin)
 - Optimize dari segi performance
Dapat menggunakan Occlusion Culling untuk tidak merender objek di luar pandangan kamera. Menggunakan Level of Detail (LOD) untuk menggunakan model dengan banyaknya vertex tergantung jarak dari kamera. Menghindari penggunaan fungsi Update() pada script, bisa diganti Coroutines. Object Pooling saat runtime. Juga bisa menggunakan Unity Profiler untuk analisa performa.
 - Optimize dari segi size game
Texture maps seperti Roughness, Metalness, dan Ambient Occlusion dapat digabung ke dalam 1 texture. Bisa juga menggunakan Texture Atlas. Menggabungkan mesh untuk mengurangi draw calls. Menggunakan Addressable assets sesuai kebutuhan. Bisa juga mengkompress texture sesuai platform tujuan.

4. Apa yang anda tahu tentang Object Pooling? Bagaimana anda menerapkan Objects Pooling di Unity? Tulis code sederhana tentang Object Pooling. (10 poin)
Semacam teknik untuk mengelola objek yang sering diperlukan, dengan cara mendaur ulangnya seperti enemy.
Untuk kodenya sudah saya coba terapkan di dalam project yang dapat diakses di folder berikut
https://github.com/alwimiftahulkaromi/imve-test/blob/main/Assets/Scripts/ObjectPool.cs
atau dapat mengklik link di bawah ini
[Object Pool Script](https://github.com/alwimiftahulkaromi/imve-test/blob/main/Assets/Scripts/ObjectPool.cs)

5. Untuk permasalahan pada soal, saya mungkin akan mengatasinya dengan cara menggunakan ScriptableObject untuk membuat base data yang nantinya akan digunakan di suatu class base GameObject. Nah dari GameObject base tersebut dapat dibuat GameObject turunan atau object dengan fungsi tambahan sesuai kebutuhan.

6. Untuk jawabannya saya gabungkan dengan No. 7

7. Jawaban untuk No. 6 dan No. 7 sudah saya buat script yang berisi method JawabanNo6() dan JawabanNo7(). Dapat diakses pada folder berikut
https://github.com/alwimiftahulkaromi/imve-test/blob/main/Assets/Scripts/JawabanSoal.cs
atau dapat menklik link di bawah ini
[Script Jawaban Soal Nomor 6 dan 7](https://github.com/alwimiftahulkaromi/imve-test/blob/main/Assets/Scripts/JawabanSoal.cs)
Sudah saya sediakan juga scene bernama JawabanSoalScene di dalam project, yang dapat dijalankan menggunakan Unity untuk melihat output dari setiap method-nya di console.
