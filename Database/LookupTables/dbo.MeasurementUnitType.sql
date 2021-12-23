delete from dbo.MeasurementUnitType

insert into dbo.MeasurementUnitType(MeasurementUnitTypeID, MeasurementUnitTypeName, MeasurementUnitTypeDisplayName, LegendDisplayName, SingularDisplayName, NumberOfSignificantDigits) values 
(1, 'Acres', 'Acre (acres)', 'acres', 'Acre', 2),
(2, 'Miles', 'Mile (miles)', 'miles', 'Mile', 2),
(3, 'SquareFeet', 'Square Foot (sq ft)', 'sq ft', 'Square Foot', 2),
(4, 'LinearFeet', 'Linear Foot (lf)', 'lf', 'Linear Foot', 2),
(5, 'Kilogram', 'Kilogram (kg)', 'kg', 'Kilogram', 2),
(6, 'Number', 'Each Unit (number)', 'number', 'Each Unit', 0),
(7, 'Pounds', 'Pounds (lbs)', 'lbs', 'Pound', 2),
(8, 'Tons', 'Ton (tons)', 'tons', 'Ton', 2),
(9, 'Dollars', 'Dollar ($)', '$', 'Dollar', 0),
(10, 'Parcels', 'Parcel (parcels)', 'parcels', 'Parcel', 0),
(11, 'Percent', 'Percent (%)', '%', 'Percent', 0),
(12, 'Therms', 'Therm (therms)', 'therms', 'Therm', 2),
(13, 'PartsPerMillion', 'Part Per Million (ppm)', 'ppm', 'Part Per Million', 3),
(14, 'PartsPerBillion', 'Part Per Billion (ppb)', 'ppb', 'Part Per Billion', 3),
(15, 'MilligamsPerLiter', 'Milligram Per Liter (mg/L)', 'mg/L', 'Milligram Per Liter', 2),
(16, 'NephlometricTurbidityUnit', 'Nephlometric Turbidity Unit (ntu)', 'ntu', 'Nephlometric Turbidity Unit', 1),
(17, 'Meters', 'Meter (m)', 'm', 'Meter', 1),
(18, 'PeriphytonBiomassIndex', 'Periphyton Biomass Index (pbi)', 'pbi', 'Periphyton biomass index', 0),
(19, 'AcreFeet', 'Acre-Foot (acre-feet)', 'acre-ft', 'Acre-Foot', 0),
(20, 'Gallon', 'Gallon (gallons)', 'gallons', 'Gallon', 0),
(21, 'CubicYards', 'Cubic Yard (cubic yards)', 'cubic yards', 'Cubic Yard', 0),
(22, 'MetricTons', 'Metric Ton (metric tons)', 'metric tons', 'Metric Ton', 0),
(23, 'Hours', 'Hour (hours)', 'hours', 'Hour', 0),
(24, 'Count', 'Each Unit (count)', 'count', 'Each Unit', 0),
(25, 'Feet', 'Foot (ft)', 'ft', 'Foot', 2),
(26, 'Inches', 'Inch (in)', 'in', 'inch', 2),
(27, 'InchesPerHour', 'Inches Per Hour (in/hr)', 'in/hr', 'Inches Per Hour', 2),
(28, 'Seconds', 'Second (s)', 's', 'Second', 0),
(29, 'PerSquareKilometer', 'Per Square Kilometer (per sq km)', 'per sq km', 'Per Square Kilometer', 1),
(30, 'Cubic Foot / Second', 'Cubic Foot / Second (cfs)', 'cfs', 'Cubic Foot / Second', 2),
(31, 'Hectare', 'Hectare (ha)', 'ha', 'Hectare', 0),
(32, 'Kilometer', 'Kilometer (km)', 'km', 'Kilometer', 1),
(33, 'ChemicalConcentrationWetWeight', 'Chemical Concentration Wet Weight (ng/g wet weight)', 'ng/g wet weight', 'Chemical Concentration Wet Weight', 1),
(34, 'ChemicalConcentrationLipidWeight', 'Chemical Concentration Lipid Weight (ng/g lipid weight)', 'ng/g lipid weight', 'Chemical Concentration Lipid Weight', 1),
(35, 'CanopyBulkDensity', 'Canopy Bulk Density (kg/m^3)', 'kg/m^3', 'Canopy Bulk Density', 2),
(36, 'LinearStreamMiles', 'Linear Stream Miles', 'linear stream miles', 'Linear Stream Mile', 2),
(37, 'Celsius', 'Celsius (C)', 'C', 'Celsius', 2),
(38, 'PerSquareMeter', 'Per Square Meter (per sq m)', 'per sq m', 'Per Square Meter', 2),
(39, 'KilowattHour', 'Kilowatt-hours', 'kWh', 'Kilowatt-hour', 2)