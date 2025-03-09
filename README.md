# User Management API 

این پروژه یک API برای مدیریت کاربران است که با استفاده از **ASP.NET Core 8**, **Onion Architecture**, **CQRS**, و **JWT Authentication** پیاده‌سازی شده است.

## 🛠 ویژگی‌های پروژه:
- **CRUD کامل** کاربران با `GET`, `POST`, `PUT`, `PATCH`, `DELETE`
- **Onion Architecture** برای جداسازی لایه‌ها
- **Swagger** برای مستندسازی API
- موارد زیر به پروژه مرحله به مرحله اضافه خواهند شد:
- **CQRS و Mediator** برای مدیریت کوئری‌ها و کامندها
- **JWT Authentication** برای احراز هویت امن
- **SSO با Google**

## نحوه‌ی راه‌اندازی پروژه

1. کلون کردن پروژه:

git clone https://github.com/SaeedehArabani/Shariff.git 

2.	ورود به دایرکتوری پروژه:
3.	نصب وابستگی‌ها:
dotnet restore

4.	اجرای پروژه:
cd UserManagement.API
dotnet run
