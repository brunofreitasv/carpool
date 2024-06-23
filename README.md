# Carpool - taxi service

This project aims to develop a comprehensive taxi booking and ride management system, similar to popular platforms like Uber. Here, you'll find a detailed overview of the project's scope, features, use cases, data model, and a comprehensive list of functionalities.

## Project Scope

The Taxi Online Service encompasses a wide range of functionalities, catering to both passengers and drivers. It covers the entire ride-hailing process, from account creation to ride completion and payment processing.

## Key Features

### Account Management

- Users can create accounts as either passengers or drivers.
- Account creation involves providing essential information like name, email, CPF (Brazilian tax ID), password, and for drivers, car plate number.
- Unique email addresses are enforced to prevent duplicate accounts.
- While CPFs can be associated with multiple accounts, only one account can be active at a time.

### Ride Management

- Passengers can request rides by specifying their pickup and drop-off locations (latitude and longitude coordinates).
- Upon requesting a ride, passengers are not initially charged, and the fare is calculated only after the ride is completed.
- Rides are initially in the 'REQUESTED' status.
- Passengers can view the 'RIDE ID' upon requesting a ride.
- Passengers with ongoing rides cannot request new ones.

### Driver Actions

- Drivers can accept requested rides, changing their status to 'ACCEPTED'.
- Once a ride is accepted, the driver cannot accept any other requests.
- Drivers can only accept rides in the 'REQUESTED' status.

### Ride Progression

- Once a passenger enters the car, the driver can start the ride, changing its status to 'IN PROGRESS'.
- During the ride, the driver's position is updated every minute, recording the ride's trajectory (latitude and longitude).

### Ride Completion and Payment

- Upon reaching the destination, the driver can end the ride, changing its status to 'COMPLETED'.
- The fare is calculated based on the total distance traveled, using the following pricing table:
    - Weekdays (8:00 AM - 10:00 PM): R$2.10 per km
    - Weekdays (10:00 PM - 8:00 AM): R$3.90 per km
    - Sundays (8:00 AM - 10:00 PM): R$2.90 per km
    - Sundays (10:00 PM - 8:00 AM): R$5.00 per km
- This dynamic pricing ensures a fair fare for both passengers and drivers, considering factors like traffic, detours, and longer routes with changing pricing zones.

### Ride Cancellation

- Both passengers and drivers can cancel rides, as long as the ride is not 'COMPLETED' or 'CANCELED'.
Payment Processing
- Once the fare is calculated, the payment is processed.