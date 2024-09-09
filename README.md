This is the asp .net web application having two forms "CP_FUND_OPTION_FORM" and "CP_FUND_NOMINATION_FORM". The application have a Login page where user can login to fill the forms. Home page is the welcome page. The nav bar on all pages help users to navigate between different pages.


***About files***

1. **Login.aspx**
   This file contains the design and layout for the login page. It includes form fields for username and password, styled using HTML, CSS, and Bootstrap to ensure a responsive interface. It checks for user 
   input and interacts with the backend SQL database for authentication.
2. **Login.aspx.cs**
   This backend file handles the logic for authenticating users. It checks the credentials against the database and ensures that only active users can log in. If the credentials are valid, it initiates a 
   session and redirects users to the homepage.
3. **Home.aspx**
   This file defines the homepage layout, providing navigation options for users to access forms or other sections. It uses Bootstrap for responsive design, ensuring a smooth user experience across devices.
4. **Home.aspx.cs**
   This file manages the logic for the homepage, including session validation. It checks if the user is logged in before allowing access to the homepage content and automatically redirects to the login page 
   if the session expires.
5. **OPTION_FORM.aspx**
   The frontend for the first form where users submit their details. It includes various fields with validation constraints using JavaScript, Bootstrap for form styling, and modal dialogs to display success 
   messages upon submission.
6.  **OPTION_FORM.aspx.cs**
   This file contains the logic for processing form submissions. It ensures that the form data is correctly validated and saved to the SQL database, with constraints to prevent multiple submissions by the 
   same user.
7. **NOMINATION_FORM.aspx**
   The frontend design for the second form, allowing users to fill out nomination details. Like the other form, it includes validation and a modal for successful submissions. The form uses Bootstrap for 
   responsiveness.
8.  **NOMINATION_FORM.aspx.cs**
   This backend file handles form submission logic for the nomination form. It validates user inputs, ensures the user can submit only once, and saves the information in the database. If successful, a message 
   is displayed via a Bootstrap modal.
    
# Asim-Raza
