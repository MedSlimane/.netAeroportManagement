# Entity Framework Core Configuration - Implementation Summary

## Part I: Data Annotations - COMPLETED ✓

### 1. Passenger Class Annotations
- **PassportNumber**: `[StringLength(7)]` - Fixed length of 7 characters
- **FirstName**: 
  - `[MinLength(3)]` - Minimum 3 characters
  - `[MaxLength(25)]` - Maximum 25 characters  
  - `[ErrorMessage]` - Custom error messages for validation
- **BirthDate**:
  - `[Display(Name = "Date of Birth")]` - Display name for UI
  - `[DataType(DataType.Date)]` - Date validation
- **EmailAddress**: `[EmailAddress]` - Email format validation
- **TelNumber**: `[RegularExpression(@"^\d{8}$")]` - Must contain exactly 8 digits

### 2. Plane Class Annotations
- **Capacity**: `[Range(1, int.MaxValue)]` - Must be a positive integer

### 3. Flight Class Annotations
- **PlaneId**: `[ForeignKey(nameof(Plane))]` - Foreign key to Plane entity

### 4. Staff Class Annotations
- **Salary**: `[Column(TypeName = "decimal(18,2)")]` - Monetary value configuration

## Part II: Fluent API Configuration - COMPLETED ✓

### 1. Created Configurations Folder
Location: `/AM.Infrastructure/Configurations/`

### 2. PlaneConfiguration Class
- Implements `IEntityTypeConfiguration<Plane>`
- Configures `PlaneId` as the primary key
- Sets table name to `"MyPlanes"`
- Renames `Capacity` column to `"PlaneCapacity"`

### 3. FlightConfiguration Class
- Implements `IEntityTypeConfiguration<Flight>`
- Configures many-to-many relationship between Flight and Passenger
  - Uses `FlightPassenger` join table
- Configures one-to-many relationship between Flight and Plane
  - Sets `PlaneId` as foreign key

### 4. Updated AMContext Class
- Added `OnModelCreating` method to apply configurations:
  - `modelBuilder.ApplyConfiguration(new PlaneConfiguration())`
  - `modelBuilder.ApplyConfiguration(new FlightConfiguration())`

## Part III: Conventions - COMPLETED ✓

### ConfigureConventions Method
- Configured all `DateTime` properties to use `"date"` column type instead of default `"datetime2"`
- Implementation:
```csharp
configurationBuilder.Properties<DateTime>()
    .HaveColumnType("date");
```

## Next Steps: Database Migration

To apply these changes to the database, run:

```bash
cd /Users/slimane/RiderProjects/ConsoleApp1
dotnet ef migrations add AnnotationsAndFluentAPI -p AM.Infrastructure -s ConsoleApp1
dotnet ef database update -p AM.Infrastructure
```

## Files Modified/Created

### Modified:
1. `/AM.ApplicationCore/Domains/Passenger.cs` - Added data annotations
2. `/AM.ApplicationCore/Domains/Plane.cs` - Added Range annotation for Capacity
3. `/AM.ApplicationCore/Domains/Flight.cs` - Added ForeignKey annotation
4. `/AM.ApplicationCore/Domains/Staff.cs` - Added Column annotation for Salary
5. `/AM.Infrastructure/AMContext.cs` - Added OnModelCreating and ConfigureConventions methods
6. `/ConsoleApp1.sln` - Fixed syntax error (missing EndProject)

### Created:
1. `/AM.Infrastructure/Configurations/PlaneConfiguration.cs` - Fluent API configuration for Plane
2. `/AM.Infrastructure/Configurations/FlightConfiguration.cs` - Fluent API configuration for Flight

## All Requirements Completed

✓ Section I: Annotations for all domain classes
✓ Section II: Fluent API configurations with custom table/column names
✓ Section III: Convention configuration for DateTime columns

