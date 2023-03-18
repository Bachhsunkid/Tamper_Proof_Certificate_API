show variables like 'max_connections';
SET GLOBAL max_connections = 1024;

GRANT ALL PRIVILEGES ON * TO another_user@'sql12.freesqldatabase.com';
-- DELETE FROM user WHERE UserCode = 100005;
--  DELETE FROM user; 
 DELETE FROM certificate;
 DELETE FROM contact;

SELECT * FROM user u;
SELECT * FROM certificate c;
SELECT * from contact c;


-- ==================Insert into user=======================
-- tao truong
CALL proc_user_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'University of Transport and Communications', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679067306/Logo/f513d3d1-faa5-404d-a3ae-08221608e764.jpg');

-- tao sinh vien
CALL proc_user_insert('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl','Tran Huy Hiep', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu','Trinh Xuan Bach', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');


CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks1','Nguyen Van A', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks2','Nguyen Van B', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks3','Nguyen Van C', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks4','Nguyen Van D', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks5','Nguyen Van E', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks6','Nguyen Van F', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks7','Nguyen Van G', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks8','Nguyen Van H', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks9','Nguyen Van I', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');

-- ==================Create cert==================
-- Create cert
 CALL proc_certificate_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl','Education Certificate','The Degree Of Engineer', 'addr_test1qr4fkykkejglg6fz7vydddvwezc4vr4rpecp8nc5psc27zhcq7w00py4yvvu390jd40vzj646ra9c809xpwcnqwawg4q0xgwj3','Tran Huy Hiep','2001/12/31',2022,'Excellent','Full-time');
 CALL proc_certificate_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu','Education Certificate','The Degree Of Engineer', 'addr_test1qps5dtz389tm04qnt8nscmr2wc6tjhjwv3vx98j06ykgu23ka2gm6amddyamqjt2agngj8s8vhzhf5hm6jsgmw5umvuqxe3j55','Trinh Xuan Bach','2002/10/30',2023 ,'Good','Full-time');

-- sinh vien chap nhan ket noi theo id contact
 CALL proc_contact_accept('94b35923-c08e-11ed-8713-54e1ad6c2368'); 
 CALL proc_contact_accept('94b897ba-c08e-11ed-8713-54e1ad6c2368');
 CALL proc_contact_accept('94bc47ac-c08e-11ed-8713-54e1ad6c2368');

-- ki bang theo id bang
CALL proc_certificate_sign('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');
CALL proc_certificate_sign('94b76a3b-c08e-11ed-8713-54e1ad6c2368');

-- gui bang theo id bang
CALL proc_certificate_send('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');


-- dashboard nha truong
CALL proc_dashbroad_GetInfor('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', @v_Username, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Username, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;

-- dashbroad sinh vien
CALL proc_dashbroad_GetInfor('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl', @v_Username, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Username, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;


CALL proc_Certificate_GetAllIssued('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc');

CALL proc_Certificate_GetAllReceived('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu');

CALL Proc_Contact_GetAll('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc');

CALL Proc_Contact_GetAll('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl');

CALL proc_contact_accept('991473d8-c5a8-11ed-ae9e-062bff1cb1bf'); 

CALL proc_contact_delete('991473d8-c5a8-11ed-ae9e-062bff1cb1bf');
UPDATE contact c SET c.IsDeleted = 0 WHERE c.ContactID = '991473d8-c5a8-11ed-ae9e-062bff1cb1bf';

CALL proc_certificate_sign('e77a35f7-c5a8-11ed-ae9e-062bff1cb1bf');

CALL proc_certificate_send('c28136f0-c5b4-11ed-ae9e-062bff1cb1bf');

CALL proc_dashbroad_GetInfor('75e1242772997291ca75aac0755b1a164dad61a4cd035e72c1485172', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;

CALL proc_dashbroad_GetInfor('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;



