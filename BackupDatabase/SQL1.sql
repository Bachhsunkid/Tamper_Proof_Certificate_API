show variables like 'max_connections';
SET GLOBAL max_connections = 1024;

GRANT ALL PRIVILEGES ON * TO another_user@'sql12.freesqldatabase.com';
-- DELETE FROM user WHERE UserCode = 100005;
-- DELETE FROM user; 
-- DELETE FROM certificate;
-- DELETE FROM contact;

SELECT * FROM user u;
SELECT * FROM certificate c;
SELECT * from contact c;

UPDATE user u SET isverified = 1 WHERE u.UserCode ='100000'


-- ==================Insert into user=======================
-- tao truong
CALL proc_user_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'University of Transport and Communications', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679067306/Logo/f513d3d1-faa5-404d-a3ae-08221608e764.jpg');

-- tao sinh vien
CALL proc_user_insert('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl','Tran Huy Hiep', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu','Trinh Xuan Bach', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nks3','Bach 2', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');

CALL proc_user_insert('stake_test1upvadt5zw4t5uw8tzzwl0xp5kaks0svzqg6hsfekhjl0fzs7k42ll','Tran Lam Lien', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1upzlwwvcu2cfajnzdcvthqw7snp2w2vsp4yceqsph8rx8cqna2ker','Le Dinh Minh', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1upgyluuflvwk2kdjxlfzxgqrly3r72652aaa3sj0hdeqdyceq4f0h','Vu Truong Giang', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');

CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka1','Nguyen Van A', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka2','Nguyen Van B', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka3','Nguyen Van C', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka4','Nguyen Van D', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka5','Nguyen Van E', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka6','Nguyen Van F', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka7','Nguyen Van G', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka8','Nguyen Van H', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');
CALL proc_user_insert('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nka9','Nguyen Van I', 'https://res.cloudinary.com/dog4lwypp/image/upload/v1679064292/Logo/35999755-2230-4f91-a405-df5bec1c11f6.jpg');




-- ==================Create cert==================
-- Create cert
 CALL proc_certificate_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl','The Degree Of Engineer', 'addr_test1qr4fkykkejglg6fz7vydddvwezc4vr4rpecp8nc5psc27zhcq7w00py4yvvu390jd40vzj646ra9c809xpwcnqwawg4q0xgwj3','Tran Huy Hiep','2001/12/31',2022,'Excellent','Full-time');
 CALL proc_certificate_insert('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', 'stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu','The Degree Of Engineer', 'addr_test1qps5dtz389tm04qnt8nscmr2wc6tjhjwv3vx98j06ykgu23ka2gm6amddyamqjt2agngj8s8vhzhf5hm6jsgmw5umvuqxe3j55','Trinh Xuan Bach','2002/10/30',2023 ,'Good','Full-time');


-- sinh vien chap nhan ket noi theo id contact
 CALL proc_contact_accept('94b35923-c08e-11ed-8713-54e1ad6c2368'); 
 CALL proc_contact_accept('94b897ba-c08e-11ed-8713-54e1ad6c2368');
 CALL proc_contact_accept('94bc47ac-c08e-11ed-8713-54e1ad6c2368');

-- ki bang theo id bang
CALL proc_certificate_sign('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');
CALL proc_certificate_signmultiple ('"dd48bbba-c977-11ed-ae9e-062bff1cb1bf","dd21f684-c977-11ed-ae9e-062bff1cb1bf"');

-- gui bang theo id bang
CALL proc_certificate_send('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');


-- dashboard nha truong
CALL proc_dashboard_GetInfor('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc', @v_Username, @v_IsVerified,@v_Logo,@v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Banned, @v_Received);
SELECT @v_Username, @v_IsVerified, @v_Logo, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Banned, @v_Received;

-- dashbroad sinh vien
CALL proc_dashboard_GetInfor('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl', @v_Username, @v_Logo, @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Username, @v_Logo,@v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;


SELECT * FROM certificate c;

CALL proc_Certificate_GetAllIssued('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc');

CALL proc_Certificate_GetAllReceived('stake_test1uqmw4ydawakkjwasf94w5f5frcrkt3t56taafgydh2wdkwqw3nksu');

CALL Proc_Contact_GetAll('stake_test1uzjjsk25c6xc2ax57pvsvwdsncmta0nksfyvwdyq2ewlndqh9alfc');

CALL Proc_Contact_GetAll('stake_test1uruq088hsj2jxxwgjhex6hkpfd2ap7jurhjnqhvfs8why2s0w4ltl');

CALL proc_contact_accept('0bcf849b-c5bc-11ed-ae9e-062bff1cb1bf'); 

CALL proc_contact_delete('991473d8-c5a8-11ed-ae9e-062bff1cb1bf');
UPDATE contact c SET c.IsDeleted = 0 WHERE c.ContactID = '991473d8-c5a8-11ed-ae9e-062bff1cb1bf';

CALL proc_certificate_sign('e77a35f7-c5a8-11ed-ae9e-062bff1cb1bf');

CALL proc_certificate_send('c28136f0-c5b4-11ed-ae9e-062bff1cb1bf');


CALL proc_Certificate_AddTransactionLink('dd48bbba-c977-11ed-ae9e-062bff1cb1bf,dd21f684-c977-11ed-ae9e-062bff1cb1b','Test');


SELECT * from certificate c

CALL proc_certificate_signmultiple('a5121bd9-d4f9-11ed-ae9e-062bff1cb1bf,a4ee3fbd-d4f9-11ed-ae9e-062bff1cb1bf,a4ca85f1-d4f9-11ed-ae9e-062bff1cb1bf,a4a65aff-d4f9-11ed-ae9e-062bff1cb1bf,a481ba6f-d4f9-11ed-ae9e-062bff1cb1bf');
CALL proc_certificate_sendmultiple('a5121bd9-d4f9-11ed-ae9e-062bff1cb1bf,a4ee3fbd-d4f9-11ed-ae9e-062bff1cb1bf,a4ca85f1-d4f9-11ed-ae9e-062bff1cb1bf,a4a65aff-d4f9-11ed-ae9e-062bff1cb1bf');
CALL proc_certificate_banmultiple('a5121bd9-d4f9-11ed-ae9e-062bff1cb1bf,a4ee3fbd-d4f9-11ed-ae9e-062bff1cb1bf');


CALL proc_contact_accept('a30e78c8-d4f9-11ed-ae9e-062bff1cb1bf'); 
CALL proc_contact_accept('a334a345-d4f9-11ed-ae9e-062bff1cb1bf'); 
CALL proc_contact_accept('a35a01e9-d4f9-11ed-ae9e-062bff1cb1bf'); 
CALL proc_contact_accept('a37fb582-d4f9-11ed-ae9e-062bff1cb1bf'); 
CALL proc_contact_accept('a3a5d08f-d4f9-11ed-ae9e-062bff1cb1bf'); 

