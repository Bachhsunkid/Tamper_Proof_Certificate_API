show variables like 'max_connections';
SET GLOBAL max_connections = 1024;

GRANT ALL PRIVILEGES ON * TO another_user@'sql12.freesqldatabase.com';
-- DELETE FROM user WHERE UserCode = 100005;
 DELETE FROM user; 
 DELETE FROM certificate;
 DELETE FROM contact;

SELECT * FROM user u;
SELECT * FROM certificate c;
SELECT * from contact c;

-- ==================Insert into user=======================
-- tao truong
CALL proc_user_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'University of Transport and Communications', 'UTC.jpg');

-- tao sinh vien
CALL proc_user_insert('d9312da562da182b02322fd8acb536f37eb9d29fba7c49dc17255527','Tran Huy Hiep', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e25','Trinh Xuan Bach', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e26','Le Duc An', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e27','Le Duc Binh', 'student+Code.jpg');



CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28','Nguyen Van A', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e29','Nguyen Van B', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e30','Nguyen Van C', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e31','Nguyen Van D', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e32','Nguyen Van E', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e33','Nguyen Van F', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e34','Nguyen Van G', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e35','Nguyen Van H', 'student+Code.jpg');
CALL proc_user_insert('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e36','Nguyen Van I', 'student+Code.jpg');

-- ==================Create cert==================
-- Create cert

 CALL proc_certificate_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'd9312da562da182b02322fd8acb536f37eb9d29fba7c49dc17255527','Education Certificate','The Degree Of Engineer', 'addr_test1qq68a8hxmz6x295epvy5tluak0z3z9uxfk0yqsepnragz33ka2gm6amddyamqjt2agngj8s8vhzhf5hm6jsgmw5umvuqx9u8hh','Tran Huy Hiep',CURDATE(),'Good','Full-time');
 CALL proc_certificate_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e25','Education Certificate','The Degree Of Engineer', 'addr_test1qqhhtnqp0jwgtfryrpql5se9f9q0cctzcmk5x70slddwcf3x66wapyaagku48pfgu6njmsm98ml9kcu3xr2uffyhl8cq4h3zdr','Trinh Xuan Bach',CURDATE(),'Good','Full-time');
 CALL proc_certificate_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e26','Education Certificate','The Degree Of Engineer', 'addr_test1qqhhtnqp0jwgtfryrpql5se9f9q0cctzcmk5x70slddwcf3x66wapyaagku48pfgu6njmsm98ml9kcu3xr2uffyhl8cq4h3zdt','Le Duc An','2000-09-04','Excellent','Part-time');
 CALL proc_certificate_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e27','Education Certificate','The Degree Of Bachelor', 'addr_test1qqhhtnqp0jwgtfryrpql5se9f9q0cctzcmk5x70slddwcf3x66wapyaagku48pfgu6njmsm98ml9kcu3xr2uffyhl8cq4h3zdy','Le Duc Binh','1999-10-04','Excellent','Full-time');
 CALL proc_certificate_insert('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 'bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28','Education Certificate','The Degree Of Bachelor', 'addr_test1qqhhtnqp0jwgtfryrpql5se9f9q0cctzcmk5x70slddwcf3x66wapyaagku48pfgu6njmsm98ml9kcu3xr2uffyhl8cq4h3zdu','Le Thi Mai','1999-11-04','Good','Part-time');

-- sinh vien chap nhan ket noi theo id contact
 CALL proc_contact_accept('94b35923-c08e-11ed-8713-54e1ad6c2368'); 
 CALL proc_contact_accept('94b897ba-c08e-11ed-8713-54e1ad6c2368');
 CALL proc_contact_accept('94bc47ac-c08e-11ed-8713-54e1ad6c2368');

-- ki bang theo id bang
CALL proc_certificate_sign('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');
CALL proc_certificate_sign('94b76a3b-c08e-11ed-8713-54e1ad6c2368');

-- gui bang theo id bang
CALL proc_certificate_send('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');

-- ================= Test =============

CALL proc_certificate_GetPagingIssued('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', 10, 1, NULL, '', NULL, NULL, NULL);

CALL proc_certificate_GetPagingReceived('d9312da562da182b02322fd8acb536f37eb9d29fba7c49dc17255527',10,1,NULL,NULL,NULL);

CALL proc_contact_GetPaging('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7',10,1,'',NULL);

CALL proc_contact_GetPaging('d9312da562da182b02322fd8acb536f37eb9d29fba7c49dc17255527',10,1,'',NULL);

-- dashbraod nha truong
CALL proc_dashbroad_GetInfor('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;

-- dashbroad sinh vien
CALL proc_dashbroad_GetInfor('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;

UPDATE certificate c SET c.IsDeleted = 0 WHERE c.CertificateID = 'd8dd2d36-bf06-11ed-939e-54e1ad6c2368';

UPDATE certificate SET IpfsLink = 'aa' WHERE CertificateCode = '100008'



CALL proc_Certificate_GetAllIssued('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7');

CALL proc_Certificate_GetAllReceived('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28');

CALL Proc_Contact_GetAll('146d28b014f87920fa81c3b91007606d03ce0376c365befb5a3df1f7');

CALL Proc_Contact_GetAll('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28');

CALL proc_contact_accept('c8d48f5e-c356-11ed-ae9e-062bff1cb1bf'); 

CALL proc_certificate_sign('c54c7fd0-c31a-11ed-ae9e-062bff1cb1bf');

CALL proc_certificate_send('c8d422a0-c356-11ed-ae9e-062bff1cb1bf');

CALL proc_dashbroad_GetInfor('75e1242772997291ca75aac0755b1a164dad61a4cd035e72c1485172', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;

CALL proc_dashbroad_GetInfor('bf1f5570841b4ee812dc49e6111ba402813d19b3e1f8ec1e94ca9e28', @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent,@v_Received);
SELECT @v_Pending, @v_Connected, @v_Draft, @v_Signed, @v_Sent, @v_Received;


