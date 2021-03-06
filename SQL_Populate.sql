﻿INSERT INTO [dbo].[Categories]([Name],[Description])
     VALUES
('Starter','First impression is the last impression. Raise the bar with these sensational starters and set the perfect tone by kicking off your dinner party in style.'),
('Burger','The Best Burger Recipes! Sharing our secrets for making restaurant quality burgers, from the juiciest burger patties to the best buns and burger.'),
('Mexican','You can learn about our Mexican cuisines ranging from tacos, burritos, enchiladas, and more—as well as find the perfect Mexican dish for your taste.'),
('Pizza','This savory dish of Italian origin consists of round, flattened base of leavened wheat-based dough topped with tomatoes, cheese and other ingredients.'),
('Vegetarian','These foods are mostly preferred by people who don’t eat products or by-products of slaughter and processing aids from slaughter.'),
('Dessert','Beautiful dessert recipes include rich chocolate truffle layer cake and delicate cream puffs with chocolate sauce and many more.');

INSERT INTO [dbo].[MenuItems]([Name],[Description],[Price],[ImageUrl],[CategoryId])
     VALUES
('Chicken Taquitos Platter','Flour tortillas rolled around mex-seasoned chicken and mixed cheese. BBQ-style, baked, or fried golden. Served with salsa and sour cream, and your choice of home-cut fries or a side salad.',8.99,'/images/menu/1.jpg',1),
('Crocodile Skins','Seasoned potato skins, melted mixed cheese, bacon bits, and green onions. Served with sour cream.',12.99,'/images/menu/2.jpg',1),
('The Kitchen Sink','Jim''s famous buffalo wings, monkey fingers, barbecue chicken taquitos, deep-fried pickles, mozzarella sticks, onion rings, lattice fries, garlic baguette, fresh cauliflower, broccoli, carrots, and celery sticks. Served with house dressing and a sweet and sour dipping sauce.',12.99,'/images/menu/3.jpg',1),
('The Bathroom Sink','A personal size sampler of Jim''s famous kitchen sink, including Jim''s famous buffalo wings, chicken taquitos, monkey fingers, mozzarella cheese sticks, deep-fried pickles, garlic baguette, jungle rings, lattice fries, and a side of sweet-and-sour sauce.',15.99,'/images/menu/4.jpg',1),
('Spinach Dip','Spinach, artichokes, cream cheese, and sour cream seasoned with garlic, lemon, and savory spices, topped with melted mixed cheese, and served with crispy golden tortilla chips.',12.49,'/images/menu/5.jpg',1),
('Spudmania','Thinly sliced, crispy-fried chips, drizzled with Jim''s famous buffalo wing sauce and ranch dressing, served with melted mixed cheese, bacon bits, diced tomatoes, and green onions.',12.99,'/images/menu/6.jpg',1),
('Buffalo Wings','Unbreaded chicken wing section, deep-fried and dipped in a bufallo sauce.',13.99,'/images/menu/7.jpg',1),
('Chipotle Steakhouse Burger','Smothered in steak sauce and topped with mozzarella and Jim''s golden-fried onion rings. Served with chipotle mayo, lettuce, and tomatoes.',13.99,'/images/menu/8.jpg',2),
('BBQ Bacon Cheddar Burger','Char-grilled with barbeque sauce and topped with bacon, cheddar cheese, lettuce, tomatoes, and mayo.',15.79,'/images/menu/9.jpg',2),
('World Famous Headhunter Burger','Three six-ounce sirloin patties, four strips of bacon, double cheddar, lettuce, tomatoes, mayo, mustard, relish, and ketchup.',20.99,'/images/menu/10.jpg',2),
('Inferno Burger','Topped with bacon, dusted jalapeños, mozzarella cheese, lettuce, tomatoes, and inferno mayo.',15.99,'/images/menu/11.jpg',2),
('Crispy Avocado Swiss (PB)','A Lightlife plant-based patty with crispy avocado wedges, Swiss cheese, lettuce, tomato, red onion & chipotle mayo.',15.99,'/images/menu/12.jpg',2),
('Mighty MOOSE Burger','6oz Newfoundland moose patty with fried onions, cheddar cheese, lettuce, tomato, mayo, ketchup, mustard & relish on a butter grilled brioche bun.',14.99,'/images/menu/13.jpg',2),
('Tex-Mex Chicken Nachos','Topped with chicken, mixed cheese, diced tomatoes, green onions, olives, and jalapeños. Served with salsa and sour cream.',18.98,'/images/menu/14.jpg',3),
('Spicy Beef Nachos','Topped with spicy beef, mixed cheese, diced tomatoes, green onions, olives, and jalapeños. Served with salsa and sour cream.',18.98,'/images/menu/15.jpg',3),
('Chili Cheese Nachos','Topped with chili, mixed cheese, diced tomatoes, green onions, olives, and jalapeños. Served with salsa and sour cream.',18.98,'/images/menu/16.jpg',3),
('Spicy Beef Tacos','Mex-seasoned ground beef with taco sauce, lettuce, tomatoes, salsa, and mixed cheese, drizzled with sour cream.',12.99,'/images/menu/17.jpg',3),
('Chipotle Chicken Tacos','Barbeque-grilled, seasoned chicken breast with tomatoes, lettuce, and green onions. Served in soft, flame-grilled flour tortillas and drizzled with chipotle mayo.',12.99,'/images/menu/18.jpg',3),
('Most Valuable Burger','Guest favourite. Topped with cheddar, lettuce, tomatoes, red onions, pickles, and our signature cactus dip, on a brioche bun.',15.99,'/images/menu/19.jpg',2),
('Black Bean Veggie Burger','New, vegetarian. Black bean and brown rice patty with a hint of jalapeño. Topped with lettuce, tomatoes, red onions, pickles, and avocado citrus ranch, on a brioche bun.',15.79,'/images/menu/20.jpg',2),
('Bourbon BBQ Chicken','New. House‑made bourbon BBQ sauce, BBQ chicken, balsamic‑roasted red onions, pizza mozzarella, cheddar cheese, and bacon, finished with a buttermilk ranch drizzle.',13.59,'/images/menu/21.jpg',4),
('Mad Mac','New. Seasoned ground beef, bacon, white onions, cheddar, and pizza mozzarella. Topped with iceberg lettuce, chopped pickles, mac sauce, and sesame seeds.',13.59,'/images/menu/22.jpg',4),
('The Meateor','Guest favourite, spicy. Beefy bolognese sauce, pizza mozzarella, smoked ham, pepperoni, seasoned ground beef, and spicy Italian sausage.',13.59,'/images/menu/23.jpg',4),
('El Dorado','New, spicy. Signature pizza sauce, chorizo sausage, seasoned ground beef, pizza mozzarella, red onions, jalapeño peppers, and fresh tomatoes.',13.59,'/images/menu/24.jpg',4),
('Mediterranean','Vegetarian. Signature pizza sauce, pizza mozzarella, fresh spinach, fresh mushrooms, sun-dried tomatoes, feta and a pesto drizzle.',12.99,'/images/menu/25.jpg',4),
('Royal Hawaiian','New. Sweet Thai honey garlic, Gouda, provolone, Parmesan, pizza mozzarella, red onions, smoked prosciutto, bacon, grilled pineapple, and toasted sesame seeds.',13.59,'/images/menu/26.jpg',4),
('Tropical Chicken','Spicy. Alfredo sauce, pizza mozzarella, cheddar, bacon, spicy chicken breast, and grilled pineapple.',13.59,'/images/menu/27.jpg',4),
('Hawaiian','Signature pizza sauce, pizza mozzarella, grilled pineapple, and smoked ham.',11.99,'/images/menu/28.jpg',4),
('Vegetarian','Vegetarian. Signature pizza sauce, pizza mozzarella, fresh mushrooms, green peppers, onions, and fresh tomato slices.',12.99,'/images/menu/29.jpg',4),
('Cali Bowl','Freshii green smoothie, banana, mango, strawberries, granola, coconut.',9.59,'/images/menu/30.jpg',5),
('Huevos Bowl','Scrambled egg & kale, avocado, aged cheddar, black beans, salsa fresca, fiery bbq sauce.',8.39,'/images/menu/31.jpg',5),
('Buddha''s Satay','Rice noodles, broccoli, carrots, cabbage, crispy wontons, green onions, spicy peanut sauce.',10.19,'/images/menu/32.jpg',5),
('Pangoa','Brown rice, avocado, aged cheddar, cherry tomatoes, black beans, corn, cilantro, fiery BBQ sauce.',10.79,'/images/menu/33.jpg',5),
('Oaxaca','Brown rice and kale, avocado, beet slaw, black beans, corn, salsa fresca, crispy wontons, spicy yogurt sauce.',10.79,'/images/menu/34.jpg',5),
('Teriyaki Twist','Brown rice, edamame, crispy wontons, broccoli, carrots, cucumber, green onions, sesame seeds, teriyaki sauce.',9.95,'/images/menu/35.jpg',5),
('Bamboo','Brown rice, broccoli, carrots, cabbage, coconut, mushrooms, cilantro, green curry sauce.',10.79,'/images/menu/36.jpg',5),
('Cobb','Romaine and field greens, hard boiled egg, avocado, bacon, aged cheddar, tomatoes, corn, Greek yogurt ranch.',11.99,'/images/menu/37.jpg',5),
('Market','Field greens and spinach, quinoa, feta cheese, dried cranberries, beet slaw, strawberries, carrots, balsamic vinaigrette.',11.39,'/images/menu/38.jpg',5),
('Fiesta','Field greens, avocado, aged cheddar, corn, black beans, salsa fresca, cilantro lime vinaigrette.',11.59,'/images/menu/39.jpg',5),
('Umamii','Kale, brown rice, avocado, edamame, mushrooms, cucumber, cabbage, carrots, hemp seeds, ginger miso dressing.',11.15,'/images/menu/40.jpg',5),
('Kale Caesar','Kale, quinoa, crispy chickpeas, Parmesan cheese, hemp seeds, Greek yogurt caesar dressing.',10.79,'/images/menu/41.jpg',5),
('Chimi Cheesecake','Relish the taste of our classic chimi cheesecake topped with cheesecake topping.',7.99,'/images/menu/42.jpg',6),
('Mint-Chocolate Chimi Cheesecake','Savour the taste of our classic mint-chocolate cheesecake topped with cheesecake topping.',7.99,'/images/menu/43.jpg',6),
('White Chocolate Brownie Cheesecake','Enjoy the taste of our white chocolate brownie cheesecake topped with cheesecake topping.',7.99,'/images/menu/44.jpg',6),
('Bagel','Enjoy our bagel bread and share in the great tradition of the Jewish communities of Poland.',1.39,'/images/menu/45.jpg',6),
('Seasonal Fruit','Out assorted fruits are sourced from farms all across Canada and are the juiciest you can find.',4.99,'/images/menu/46.jpg',6),
('Dippable Veggies','Fresh, hand-cut veggies with dipping sauce.',3.29,'/images/menu/47.jpg',6),
('Chocolate Chip Pancakes','Ghirardelli chocolate chips cooked inside buttermilk silver dollar pancakes.',4.99,'/images/menu/48.jpg',6),
('Famous Cheesecake Apple','Granny smith apple dipped in fresh made from scratch caramel, then dipped in our white chocolate flavoured with cheesecake, and rolled in graham cracker crumbs.',10.00,'/images/menu/49.jpg',6),
('Famous Toffee Apple','Granny smith apple dipped in fresh made from scratch caramel, then dipped in our milk chocolate and rolled in toffee.',10.00,'/images/menu/50.jpg',6),
('Strawberry Sundae','Cool and creamy, the made-to-order Strawberry Sundae is prepared with velvety Vanilla Soft Serve and finished with a delicious strawberry swirl.',2.19,'/images/menu/51.jpg',6),
('Chocolate Fudge Sundae','Cool and creamy, the made-to-order Chocolate Sundae is prepared with velvety Vanilla Soft Serve and finished with a delicious chocolate fudge swirl.',2.19,'/images/menu/52.jpg',6),
('Caramel Sundae','Cool and creamy, the made-to-order Caramel Sundae is prepared with velvety Vanilla Soft Serve and finished with a delicious caramel swirl.',2.19,'/images/menu/53.jpg',6);

