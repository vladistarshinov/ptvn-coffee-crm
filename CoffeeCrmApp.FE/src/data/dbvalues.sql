SELECT * FROM "Products";
INSERT INTO "Products" (
	"Name", "Description", "Price", "IsTaxable", "IsArchived", "CreatedOn", "UpdatedOn"
)
VALUES
('Lavazza Qualita Oro', 'Арабика, средняя обжарка, вакуумная упаковка', 265, true, false, NOW(), NOW()),
('Jardin Crema', 'Cмесь арабики и робусты, средняя обжарка, вакуумная упаковка', 541, true, false, NOW(), NOW()),
('Jardin Colombia Excelso', 'Арабика, темная обжарка, вакуумная упаковка', 1124, true, false, NOW(), NOW()),
('Paulig Arabica', 'Арабика, средняя обжарка, вакуумная упаковка', 221, true, false, NOW(), NOW()),
('Lavazza Gusto Forte', 'Робуста, темная обжарка, вакуумная упаковка', 645, true, false, NOW(), NOW()),
('Carte Noire Original', 'Арабика, средняя обжарка, мягкая упаковка', 429, true, false, NOW(), NOW());