/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

/* RESTAURANTS */

INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'e0f2f53e-62ca-e511-80c7-0003ff4b79a6', N'Pub Spaghetteria La Pinta', N'https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAXBAAAAJGNiNjg3NTMxLWFhNzYtNGYxYS04OWMwLTU3ZGM3YWI2YzljMA.jpg', N'18016', N'Via Elba, 15', N'San Bartolomeo al Mare', N'IM', N'+390183405756', N'lapinta@libero.it', NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f34d5d74-86cb-e511-80c7-0003ff4b79a6', N'NiceCall', N'https://img.grouponcdn.com/deal/9dSVVFnFqUsfLeELqnQw/UG-2048x1229/v1/c700x420.jpg', N'16154', N'Via Goldoni 38', N'Genova', N'GE', N'+393662518258', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'67165e09-48cc-e511-80c7-0003ff4b79a6', N'Cocoon', N'https://media-cdn.tripadvisor.com/media/photo-s/04/ab/33/38/i-like-it.jpg', N'18038', N'Via Cavour 24', N'Sanremo', N'IM', N'+390184610772', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'db3b746c-48cc-e511-80c7-0003ff4b79a6', N'Bar Max', N'http://www.sanremonews.it/typo3temp/pics/M_f1b9803805.jpg', N'18038', N'Corso Nazario Sauro', N'Sanremo', N'IM', N'+390184503614', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'4fb0b940-9bd4-e511-80c8-0003ff4b7a48', N'Girasole Pizza & Griglia', N'https://media-cdn.tripadvisor.com/media/photo-s/0c/b4/40/80/girasole-pizza-griglia.jpg', N'18013', N'Via Diano San Pietro, 71', N'Diano Marina', N'IM', N'+390183407558', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'72e07072-9bd4-e511-80c8-0003ff4b7a48', N'Pizza & Pasta', N'https://media-cdn.tripadvisor.com/media/photo-s/08/cb/bc/c2/pizza-napoletana-fantastica.jpg', N'18013', N'Largo Torino', N'Diano Marina', N'IM', N'+390183497951', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'8c54a6b7-9bd4-e511-80c8-0003ff4b7a48', N'La Darsena', N'http://www.ristorante-ladarsena.it/images/darsena.jpg?731', N'18018', N'Via Lungomare di Levante, 213', N'Arma di Taggia', N'IM', N'+39018443579', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'ff57d9d9-9bd4-e511-80c8-0003ff4b7a48', N'The Pizza and the Furious da Nino', N'https://lh5.googleusercontent.com/p/AF1QipMllfU7DptkbfcmoSKypRqjJJ7FO9HllM-CXrPh=w208-h168-p-k-no', N'18018', N'Via Caboto, 21', N'Arma di Taggia', N'IM', N'+393773144834', N'pierrinino709@gmail.com', N'')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f2fb6cc6-43d6-e511-80c8-0003ff4b7a48', N'Hotel Cristina', N'https://media-cdn.tripadvisor.com/media/photo-s/08/a6/54/db/hotel-cristina.jpg', N'11020', N'Località Champagnet, 1', N'Verrayes', N'AO', N'+39016646184', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'3f79847d-20b5-e511-80c6-0003ff4b7a4b', N'XI Comandamento', N'https://s3-media3.fl.yelpcdn.com/bphoto/J-pAXsxoq3v4yQ_c48dcPw/l.jpg', N'18018', N'Via San Francesco, 283', N'Arma di Taggia', N'IM', N'+3938897341199', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f8ed5769-9adc-e511-80c7-0003ff4b7b4b', N'La Cueva da Vito', N'https://www.vegantour.eu/wp-content/uploads/2016/02/ingresso-locale-230x230.jpg', N'18038', N'Strada 3 Ponti angolo pista ciclabile', N'Sanremo', N'IM', N'+393495253277', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'63f8ec5a-bbdc-e511-80c7-0003ff4b7b4b', N'Pizza Time', N'https://img.grouponcdn.com/deal/9dSVVFnFqUsfLeELqnQw/UG-2048x1229/v1/c700x420.jpg', N'18018', N'Via Nino Pesce, 34', N'Arma di Taggia', N'IM', N'+390184476827', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'2f6bdc7a-69de-e511-80c7-0003ff4b7b4b', N'Notte di', N'https://media-cdn.tripadvisor.com/media/photo-s/02/75/2b/9d/notte-di.jpg', N'50041', N'Via Baldanzese, 83', N'Calenzano', N'FI', N'+390558877048', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'541c81d3-76d9-e511-80c8-0003ff4b7b50', N'Fantapizza Sanremo', N'https://media-cdn.tripadvisor.com/media/photo-s/05/47/cb/e2/fantapizza.jpg', N'18038', N'Corso Inglesi, 31', N'Sanremo', N'IM', N'+390184840553', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'e67e4596-e8c5-e511-80c6-0003ff4b7ca6', N'Glam Restaurant', N'https://media-cdn.tripadvisor.com/media/photo-s/07/04/c6/5d/glam-restaurant-sanremo.jpg', N'18038', N'Corso Inglesi, 1', N'Sanremo', N'IM', N'+390184623131', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'd31ac16d-edd7-e511-80c8-0003ff4b7faa', N'Ristorante Red Pepper', N'https://media-cdn.tripadvisor.com/media/photo-s/09/5a/c8/24/ristorante-pizzeria-red.jpg', N'18013', N'Corso Europa, 48', N'Diano Marina', N'IM', N'+390183493221', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'd527ff04-2ae6-e511-80c7-0003ff4b7fac', N'Bar Gelateria Ligure', N'https://igx.4sqi.net/img/general/200x200/72114764_fRQUOUJzopWlFv8RppGhrpbBYn4GUqrQH59GwmKIbnk.jpg', N'18018', N'Piazza', N'Arma di Taggia', N'IM', N'', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'a6529310-ece6-e511-80c7-0003ff4b7fac', N'Piccolo Bar Antoine', N'https://media-cdn.tripadvisor.com/media/photo-s/07/ae/48/dd/romantica-terrazza-sul.jpg', N'18013', N'Via Aurelia Ovest', N'Diano Marina', N'IM', N'+390183498056', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'a9e15a97-ded4-e711-80c2-000d3a2094a7', N'TBSP Spot Testaccio', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00153', N'Via Aldo Manuzio 66F', N'Roma', N'RM', N'+390693380758', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'51c1bfee-d869-e611-80c3-000d3a214fbc', N'Ristorante Bruno', N'https://ordeatstorage.blob.core.windows.net/owners/51c1bfee-d869-e611-80c3-000d3a214fbc/logo.PNG', N'18038', N'Via al Mare, 31', N'Sanremo', N'IM', N'', N'info@bruno.it', NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'38457976-beed-e511-80c8-000d3a229495', N'La Pineta - Ristorante & Pizzeria', N'http://www.albergolapineta.it/wp-content/uploads/2016/03/slide_1.jpg', N'11024', N'Località Zerbio 1', N'Pontey', N'AO', N'+390166530464', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f6488f63-89ef-e511-80c8-000d3a229495', N'Cafe Noir', N'https://media-cdn.tripadvisor.com/media/photo-s/0a/99/b1/55/flawless-cappuccino.jpg', N'18013', N'Via Genala, 13', N'Diano Marina', N'IM', N'', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'd258a91d-b0e7-e511-80c7-000d3a2297d6', N'Beach Ristorante', N'http://www.ristorantebeach.it/media/k2/items/cache/ffee2447b152494b43d9816faaea83c8_XL.jpg', N'18013', N'Viale Torino, 10', N'Diano Marina', N'IM', N'+390183494322', NULL, N'http://www.ristorantebeach.it/')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f484bbb7-2eea-e511-80c7-000d3a2297d6', N'Nuovo Italo''s Trattoria', N'https://static.wixstatic.com/media/4161e0_f687bafba1174e2386926a2f3a34963b.jpg/v1/fill/w_126,h_118,al_c,q_80,usm_0.66_1.00_0.01/4161e0_f687bafba1174e2386926a2f3a34963b.jpg', N'18013', N'Via Genala, 22', N'Diano Marina', N'IM', N'+393493400907', NULL, N'http://www.nuovoitalostrattoria.com/')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'63ffc0be-5f14-40e6-9da3-16c3145c6bb3', N'Bomber', N'https://ordeatstorage.blob.core.windows.net/owners/63ffc0be-5f14-40e6-9da3-16c3145c6bb3/logo1.jpg', N'18018', N'Via Aurelia Ponente 226', N'Arma di Taggia', N'Imperia', N'+393496384091', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'a64c8f8c-4416-4d3b-95f9-2890ba38e208', N'Bomber 2.0', N'https://ordeatstorage.blob.core.windows.net/owners/a64c8f8c-4416-4d3b-95f9-2890ba38e208/logo.jpg', N'18018', N'Via Lungomare, 17', N'Arma di Taggia', N'IM', N'+393473866451', NULL, N'')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'e49b8933-3e8f-4010-9990-314d191cded9', N'TBSP Gallia', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00135', N'Via Gallia', N'Roma', N'RM', N'', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'2ebf175e-333d-4c15-b004-4c912eb3c8f9', N'Acqua e Farina', N'https://ordeatstorage.blob.core.windows.net/owners/2ebf175e-333d-4c15-b004-4c912eb3c8f9/logo.jpg', N'18100', N'Via Magenta', N'Imperia', N'IM', N'+390183276106', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'8a1e76ea-a9d0-4d74-b77d-4f65795a42ba', N'Bar Il Muretto', N'https://ordeatstorage.blob.core.windows.net/owners/8a1e76ea-a9d0-4d74-b77d-4f65795a42ba/logo.jpg', N'18018', N'C. Colombo 11', N'Arma di Taggia', N'Imperia', N'+390184716348', N'nikluna73@gmail.com', N'')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'2f690070-e527-44a5-96cd-52c71fb885a0', N'Chicken ''n Chicken Torino V.Emanuele', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'10121', N'Corso Vittorio Emanuele II, 29', N'Torino', N'TO', N'+390117900807', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'3db6be42-3766-e511-82b0-543530d89d34', N'TRYME! Ameasyng Restaurant', N'https://ordeatstorage.blob.core.windows.net/users-photos/ordinamy.png', N'00000', N'Lungomare 1', N'Riccione', N'RN', N'+3955555599', N'demo@ordeat.net', N'http://www.ordeat.net')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'419fc8ec-4c4c-4bbb-a9a1-5b41817e63fc', N'Fantapizza', N'https://ordeatstorage.blob.core.windows.net/owners/419fc8ec-4c4c-4bbb-a9a1-5b41817e63fc/logo.png', N'18013', N'Generale Ardoino', N'Diano Marina', N'138', N'3274244035', N'celentano@fantapizza.it', NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'0ec29c70-70e5-4d24-b5c0-60cad2d4349b', N'Chicken ''n Chicken Nice Malausséna', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'', N'Avenue Malausséna, 2', N'Nice', N'', N'+340981134544', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'b76a48dd-6810-4a0c-a0d8-61655983a9ad', N'Chicken ''n Chicken Genova', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'16121', N'Via Walter Fillak, 94R', N'Genova', N'GE', N'+390104036756', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'c235d4a3-4f35-4254-9717-747c6a638fcd', N'Chicken ''n Chicken Erba', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'22036', N'Via delle Grigne, 1', N'Erba', N'CO', N'+39031611076', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'f49a1e54-1fd9-43d4-9ffb-7d1c3d70629b', N'Chicken ''n Chicken Livorno', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'57121', N'Via G. Garibaldi, 162', N'Livorno', N'LI', N'+390586371256', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'2d4f5839-9c2b-4134-b3e9-89c9b65951dd', N'Chicken ''n Chicken La Spezia', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'19121', N'Piazza Giuseppe Garibaldi, 4-5', N'La Spezia', N'SP', N'+390187777956', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'da803061-3c94-49f8-8dd9-8be37a097d45', N'Orto', N'https://ordeatstorage.blob.core.windows.net/owners/da803061-3c94-49f8-8dd9-8be37a097d45/logo.jpg', N'18100', N'Piazza de Amicis, 13', N'Imperia', N'IM', N'0183960349', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'c2d5d676-4d2d-4933-90dc-8da23846a6e5', N'TBSP Spot Ponte Milvio', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00135', N'Piazzale di Ponte Milvio 12a', N'Roma', N'RM', N'', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'52afa058-964d-4cfb-b1f0-9c93ac5f29c2', N'Istituto Istr. Sup. G. Ruffini', NULL, N'18100', N'Via Terre Bianche 2', N'Imperia', N'IM', N' NULL', NULL, NULL)
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'7e27df2a-23e3-4702-a024-b8b8b627e7e4', N'Chicken ''n Chicken Nice Delfino', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'', N'16 Boulevard Gènèral Louis Delfino', N'Nice', N'', N'+340489143578', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95', N'Chicken ''n Chicken Sanremo', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'18038', N'Piazza Eroi Sanremesi, 57', N'Sanremo', N'IM', N'+390184716198', N'', N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'72d5a84e-5cf5-421f-9cb0-d581b160cb7f', N'Chicken ''n Chicken Vicenza', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'36100', N'Corso San Felice Fortunato, 222', N'Vicenza', N'VI', N'+390444960392', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'77b2528e-5422-4089-a221-d5c597454a25', N'Chicken ''n Chicken Torino G.Cesare', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'10121', N'C.so Giulio Cesare 162/a', N'Torino', N'TO', N'+390112059724', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'a379d958-6f06-465a-9d77-d613afee49be', N'TBSP FRANCHISE', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00183', N'Via Gallia', N'Roma', N'RM', N'067000488', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'32918caa-b378-4aa6-86dc-d7a80a3505c6', N'Chicken ''n Chicken Bordighera', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'18012', N'Via Vittorio Emanuele II, 134', N'Bordighera', N'IM', N'+390184263118', NULL, N'http://www.chickennchicken.com')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'297a9c47-0deb-4412-99cf-d9add2656750', N'TBSP Academy', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00183', N'Via Gallia', N'Roma', N'RM', N'067000488', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'ace54582-a608-4931-ad8d-e503359f4f7c', N'7 Luppoli Milano', N'https://ordeatstorage.blob.core.windows.net/owners/ace54582-a608-4931-ad8d-e503359f4f7c/logo.jpg', N'20139', N'Viale Ortles 31/A', N'Milano', N'MI', N'+393319060383', N'info@7luppolimilano.it', N'www.7luppolimilano.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'1b307b5b-1cdc-4aab-8a8f-e70d7eeca36c', N'TBSP Truck', N'https://ordeatstorage.blob.core.windows.net/owners/c2d5d676-4d2d-4933-90dc-8da23846a6e5/logo.png', N'00183', N'Via Gallia', N'Roma', N'RM', N'067000488', N'info@tbsp.it', N'www.tbsp.it')
GO
INSERT [dbo].[Restaurants] ([Id], [Name], [ImageUrl], [Address_PostalCode], [Address_Street], [Address_Location], [Address_Province], [PhoneNumber], [Email], [WebSite]) VALUES (N'9075aada-dfbf-4362-89b7-eb05d8b664b6', N'Chicken ''n Chicken Veniano', N'https://ordeatstorage.blob.core.windows.net/owners/a31e8c1e-51f5-4b9c-a6a8-c5203d31ff95/logo.png', N'22070', N'Via Manzoni, 30', N'Veniano', N'CO', NULL, NULL, N'http://www.chickennchicken.com')
GO