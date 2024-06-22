# Parking System
## Deskripsi
Sistem parkir ini dibangun menggunakan .NET 5 dan berfungsi sebagai aplikasi console untuk mengelola parkir kendaraan. Fitur utama termasuk check-in, check-out, laporan status parkir, dan informasi kendaraan berdasarkan nomor polisi, warna, dan jenis kendaraan.
## Instalasi
1. Pastikan Anda telah menginstal .NET 5 SDK. Anda dapat mengunduhnya dari [sini](https://dotnet.microsoft.com/download/dotnet/5.0).
2. Clone repository ini:
    ```sh
    git clone https://github.com/username/repository-name.git
    ```
3. Navigasikan ke direktori proyek:
    ```sh
    cd repository-name
    ```
4. Bangun proyek:
    ```sh
    dotnet build
    ```
5. Jalankan proyek:
    ```sh
    dotnet run
    ```
## Penggunaan
Setelah menjalankan `dotnet run`, Anda dapat memasukkan perintah berikut untuk mengelola sistem parkir:

```sh
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park B-1234-XYZ Putih Mobil
Allocated slot number: 1

$ park B-9999-XYZ Putih Motor
Allocated slot number: 2

$ leave 4
Slot number 4 is free

$ status
Slot    No.          Type    Registration No Colour
1       B-1234-XYZ   Mobil   Putih
2       B-9999-XYZ   Motor   Putih

$ type_of_vehicles Motor
2

$ type_of_vehicles Mobil
4

$ registration_numbers_for_vehicles_with_ood_plate
B-9999-XYZ, D-0001-HIJ, B-2701-XXX

$ registration_numbers_for_vehicles_with_event_plate
B-1234-XYZ, B-3141-ZZZ

$ registration_numbers_for_vehicles_with_colour Putih
B-1234-XYZ, B-9999-XYZ, B-333-SSS

$ slot_numbers_for_vehicles_with_colour Putih
1, 2, 4

$ slot_number_for_registration_number B-3141-ZZZ
6

$ slot_number_for_registration_number Z-1111-AAA
Not found

$ exit
```

### 5. Struktur Proyek
Struktur direktori dan file utama dalam proyek.

```markdown
## Struktur Proyek
ParkingSystem/
│
|-- ParkingSystem.sln        # File solusi untuk proyek
|-- Program.cs               # File utama yang mengandung logika console
|-- Models                   # Folder yang berisi ParkingLot.cs
    |-- ParkingLot.cs        # Kelas yang mengelola lot parkir dan kendaraan
|-- obj/                     # Folder keluaran objek yang dihasilkan oleh .NET
|-- bin/                     # Folder keluaran biner yang dihasilkan oleh .NET

