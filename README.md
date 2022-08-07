# ASP.NET 6 Emailing with Minimal APIs
Sending Emails in ASP.NET 6 &amp; Minimal apis Apps using Gmail smtp

To successfuly start the project we have to follow the following steps:

### Enable 2 Step-Verification : 
Go to https://myaccount.google.com/security

- Then under the “Signing in to Google” section, we can see that 2-Step Verification is off – so we have to click on it
- Click Get Started, provide your password, and confirm the code by providing a mobile number
- If everything goes well, you should see the Turn On option, so just click on it

### Add app password :

Under 2Step-Verification, You should see App Passwords

- Click on it
- Provide a password
- Click the Select app menu and choose the Other (Custom Name) option
- Now, all we have to do is to provide any name we like for our app and click the Generate button
- Copy the generated password and then paste it in ```EmailConfiguration:Password``` in ```appsettings.json``` in our **ASP.NET Project**
- Type your email in ```EmailConfiguration:From``` and ```EmailConfiguration:Username``` in ```appsettings.json```

![image](https://user-images.githubusercontent.com/64654197/183298855-755fe4e7-0eba-49ef-a4b9-afaa780d2f7f.png)

### Now you can run your app using CTRL + F5 and send your email using POSTMAN or INSOMNIA

![image](https://user-images.githubusercontent.com/64654197/183299140-8fef9259-f457-4606-a525-614c2ad79560.png)

### Don't forget to add the recipient email in the url parameter:
![image](https://user-images.githubusercontent.com/64654197/183299225-d30dc5d5-7c05-40ef-bdbc-9b0a1170c1ec.png)

