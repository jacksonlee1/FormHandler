#File Uploader

###File Upload Handler and Email Service built in .NET Core

**Getting Started**

1. Update AppSettings and User Secrets
- user secrets:
>EX USING GMAIL SMTP: 

`  "EmailConfiguration": {
    "From": "EMAIL",
    "SmtpServer": "smtp.gmail.com",
    "Port": 465,
    "Username": EMAIL ",
    "Password": "PASSWORD"
  },`
> *not your gmail password. must use app password

- app settings:


`
  "FileConfiguration":{
    "UploadBasePath":"PATH/TO/YOUR/UserUploads",
    "AllowedExtensions":".jpg,.bmp,.gif,.png,.jpeg"
  },

2 run dotnet publish 

