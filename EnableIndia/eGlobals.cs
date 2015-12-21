using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Configuration;


namespace EnableIndia
{
    public class eGlobals
    {
        public struct dayThoughts
        {
            public int tId;
            public string tDes;
            public dayThoughts(int tidno, string tDess)
            {
                this.tId = tidno;
                this.tDes = tDess;
            }
        }

        public static dayThoughts[] dt = {
                    new dayThoughts (1, "The art of being wise is the art of knowing what to overlook."),
                    new dayThoughts (2, "Coming together is a beginning,keeping together is progress and working together is success."),
                    new dayThoughts (3, "The only disability in life is a bad attitude."),
                    new dayThoughts (4, "Those who stand for nothing fall for anything."),
                    new dayThoughts (5, "Kind words can be short and easy to speak,but their echoes are truly endless."),
                    new dayThoughts (6, "Remember,we all stumble,everyone of us .thats why its a comfort to go hand in hand."),
                    new dayThoughts (7, "Hatred is self-punishment.."),
                    new dayThoughts (8, "The true measure of a man is how he treats some one who can do absolutely no good."),
                    new dayThoughts (9, "Leaders don't create followers, they create more leaders."),
                    new dayThoughts (10, "That man is richest whose pleasures are cheapest."),      
                    new dayThoughts (11, "It is often easier to fight for principles than to live up to them."),
                    new dayThoughts (12, "The opposite of love is not hate. It's indifference."),
                    new dayThoughts (13, "Not ignorance, but ignorance of ignorance is the death of knowledge."),
                    new dayThoughts (14, "What we can do for another is the test of powers , what we can suffer is the test of love."),
                    new dayThoughts (15, "If we did the things we are capable of , we would astound ourselves."),
                    new dayThoughts (16, "Don't pray when it rains if you don't pray when the sunshines."),
                    new dayThoughts (17, "Winning is a habit. Unfortunately , so is losing."),
                    new dayThoughts (18, "Soulmates  are people who bring out the best in you. They are not perfect but are always perfect for you."),
                    new dayThoughts (19, "The world is too dangerous for anything but truth, and too small for anything but love."),
                    new dayThoughts (20, "Never let your sense of morals prevent you from doing what's right."),
                    new dayThoughts (21, "The significance of a man is not what he attains but rather in what he longs to attain."),
                    new dayThoughts (22, "A man who fears suffering is already suffering from what he fears."),
                    new dayThoughts (23, "People may doubt what you say, but they will always believe what you do."),
                    new dayThoughts (24, "What you want to be is more important than what you are."),
                    new dayThoughts (25, "Happy is the person who can endure the highest and lowest fortune."),
                    new dayThoughts (26, "Following happiness is like chasing the wind or clutching the shadow."),
                    new dayThoughts (27, "The greatest risk you can take in life is to risk nothing."),
                    new dayThoughts (28, "Never deprive someone of hope. It may be all they have."),
                    new dayThoughts (29, "There are no limitations to the mind except those we acknowledge."),
                    new dayThoughts (30, "Those who make the worst use of their time are the first to complain of its shortness."),
                    new dayThoughts (31, "In the middle of difficulty lies opportunity."),
                    new dayThoughts (32, "Getting what you go after its success; but liking it while you are getting it is happiness."),
                    new dayThoughts (33, "The true measure of man's wealth is in the things he can afford not to buy."),
                    new dayThoughts (34, "A real friend who walks in when the rest of the world walks out."),
                    new dayThoughts (35, "There can be no real freedom without the freedom to fail."),
                    new dayThoughts (36, "The first step to getting the things you want out of life is decide what you want."),
                    new dayThoughts (37, "Worry does not empty tomorrow of its sorrows, it empties  today of its strength.."),
                    new dayThoughts (38, "Is the mark of an educated  mind to be able to entertain a thought without accepting it."),
                    new dayThoughts (39, "Silence is one of the hardest arguments to refute."),
                    new dayThoughts (40, "Pessimist- one who, when he has the choice of two evils, chooses bot."),
                    new dayThoughts (41, "The only man who can change his mind is the man who's got one."),
                    new dayThoughts (42, "The words and waves are always on the side of the ablest navigators."),
                    new dayThoughts (43, "Seeing's believing, but feeling's the truth."),
                    new dayThoughts (44, "Two cheers for democracy: one because it admits variety and two because it permits criticism."),
                    new dayThoughts (45, "Profitability is sovereign criterion of the enterprise."),
                    new dayThoughts (46, "No grand idea was ever born in a conference, but a lot foolish ideas have died there."),
                    new dayThoughts (47, "Whenever you see a successful business, someone once made a courageous decision."),
                    new dayThoughts (48, "Miracles sometimes occur, but one has to work terribly hard for them."),
                    new dayThoughts (49, "To love oneself is the beginning of a lifelong romance."),
                    new dayThoughts (50, "A true gentleman is one who is never unintentionally rude."),
                    new dayThoughts (51, "It is not time which needs to be managed, it is ourselves."),
                    new dayThoughts (52, "Kites rise against, not with the wind. No man has ever worked his passage anywhere in  a dead calm."),
                    new dayThoughts (53, "When two men in a business always agree, one of them is unnecessary."),
                    new dayThoughts  (54, "The man who is swimming against the stream knows the strength of it."),
                    new dayThoughts  (55, "To live with fear and not be afraid is the final test of maturity."),
                    new dayThoughts  (56, "when the power of love overcomes the love power, the world will know the peace."),
                    new dayThoughts  (57, "The hardest work is to go idle."),
                    new dayThoughts  (58, "The shortest way to do many things is to do only one thing at once."),
                    new dayThoughts  (59, "The great thing is not so much where we stand as in what direction we are moving."),
                    new dayThoughts   (60, "Politeness is a good nature regulated by good sense."),
                    new dayThoughts  (61, "If people know what they had to do to be successful , most people wouldn't."),
                    new dayThoughts  (62, "Whatever limits us, we call it fate."),
                    new dayThoughts  (63, "Maturity is the capacity to endure uncertainty."),
                    new dayThoughts  (64, "The greatest success is successful self-acceptance."),
                    new dayThoughts  (65, "When you're looking for a friend don't look for perfection, just look for friendship."),
                    new dayThoughts  (66, "Keep yourself busy with something as a busy person never has time to be unhappy."),
                    new dayThoughts  (67, "Reading is to the mind what exercise is to the body."),
                    new dayThoughts  (68, "Talent is always conscious of its own abundance , and does not object to sharing."),
                    new dayThoughts  (69, "Vices can be learnt ,even without a teacher."),
                    new dayThoughts  (70, "The test of vocation is the love of the drudgery it involves."),
                    new dayThoughts  (71, "A place for everything and everything in its place."),
                    new dayThoughts  (72, "A hateful act is the transference to others of the degradation we bear in ourselves."), 
new dayThoughts  (73, "Power is always right, weakness always wrong. Power is always insolent and despotic."),
new dayThoughts  (74, "The biggest things are always the easiest to do because there is no competition."),
new dayThoughts (75, "Science is what you know, philosophy is what you don't know."),
new dayThoughts (76, "Anything you're good at contributes to happiness."),
new dayThoughts (77, "If tomorrow were never to come, it would not be worth living today."),
new dayThoughts (78, "I hear and I forgot, I see and I remember, I do and I understand."),
new dayThoughts (79, "It takes time to save time."),
new dayThoughts (80, "Nine-tenths of wisdom consists in being wise in time."),
new dayThoughts (81, "No one can make you feel inferior without your consent."),
new dayThoughts (82, "When you cease to make a contribution, you begin to die."),
new dayThoughts (83, "Invest in inflation. It's the only thing going up."),
new dayThoughts (84, "A little learning is a dangerous thing but a lot of ignorance is just as bad."),
new dayThoughts (85, "The man who fears no truths has nothing to fear from lies."),
new dayThoughts (86, "One man with courage makes a majority."),
new dayThoughts (87, "Our greatest glory is not in never failing, but in rising up every time we fail."),
new dayThoughts (88, "Good is not good, where better is expected ."),
new dayThoughts (89, "It is wise to keep in mind that neither success nor failure is ever final."),
new dayThoughts (90, "To teach is to learn twice."),
new dayThoughts (91, "Experience enables you to recognize a mistake when you make it again."),
new dayThoughts (92, "If one does not know to which port he is sailing, no wind is favorable."),
new dayThoughts (93, "Patience has its limits. Take it too far and it's cowardice."),
new dayThoughts (94, "If liberty means anything at all, it means the right to tell people what they do not want to hear."),
new dayThoughts (95, "Life can only be understood backwards: but it must be lived forwards."),
new dayThoughts (96, "A loving person lives in a loving world. A hostile person lives in a hostile world."),
new dayThoughts (97, "Doing what's right is not the problem. It is knowing what is right."),
new dayThoughts (98, "Innovation thrives on encouragement and dies with criticism ."),
new dayThoughts (99, "If you love life, life will love you back."),
new dayThoughts (100, "If people never did silly things, nothing intelligent would ever get done."),
new dayThoughts (101, "The whole world steps aside for the  man who knows where he is going."),
new dayThoughts (102, "Always be a first rate version of yourself instead of a second rate version of somebody else."),
new dayThoughts (103, "You can never plan the future by the past."),
new dayThoughts (104, "Nobody really cares if you are miserable, so you might as well be happy."),
new dayThoughts (105, "The best way to cheer up yourself is to try to cheer up somebody else."),
new dayThoughts (106, "Remember sadness is always temporary . This , too, Shall pass."),
new dayThoughts (107, "Success is going from failure to failure without loss of enthusiasm."),
new dayThoughts (108, "An appeaser is one who feeds a crocodile hoping it will eat him last."),
new dayThoughts (109, "When your work speaks for itself, don't interrupt."),
new dayThoughts (110, "None but a fool worries about things he cannot influence ."),
new dayThoughts (111, "You must first have a lot of patience to learn to have patience."),
new dayThoughts (112, "Obstacles are those frightful things you see when you take your eyes off your goal."),
new dayThoughts (113, "It seems that ambition makes most people wish to be loved rather than to love others ."),
new dayThoughts (114, "A positive attitude may not solve all your problems, but it will annoy enough people to make it worth the effort."),
new dayThoughts (115, "It is a beggar's pride that he is not a thief."),
new dayThoughts (116, "Admiration is our polite recognition of another's resemblance to ourselves."),
new dayThoughts (117, "All change is not growth, as all movement is not forward."),
new dayThoughts (118, "When life knocks you down, try to land on your back. Because if you can look up, you can get up."),
new dayThoughts (119, "An age is called dark, not because light fails to shine, but because people refuse to see it."),
new dayThoughts (120, "The game of life is not so much in holding a good hand as in playing a poor well."),
new dayThoughts (121, "Love is an act of endless forgiveness: a tender look that becomes a habit."),
new dayThoughts (122, "Progress is impossible without change, and those who cannot change their minds cannot change anything."),
new dayThoughts (123, "A fanatic is one who can't change his mind and won't change the subject ."),
new dayThoughts (124, "Do not go where the path may lead, go instead where there is no path and leave a trail."),
new dayThoughts (125, "To be enthusiastic, act enthusiastically,  act as if you cannot fail."),
new dayThoughts (126, "You are either climbing the ladder of success or coming down - the choice is yours ."),
new dayThoughts (127, "The difference between great and good is a little extra effort."),
new dayThoughts (128, "People who begin many things, finish just a few ."),
new dayThoughts (129, "From fortune to misfortune is a short step: from misfortune to fortune is a long way."),
new dayThoughts (130, "Great things are done more through courage than through wisdom."),
new dayThoughts (131, "The key to management is influence , not authority."),
new dayThoughts (132, "You are not defeated unless you believe you are."),
new dayThoughts (133, "Experience is the most efficient tool for transforming innovation."),
new dayThoughts (134, "Success depends more on common sense than on genius."),
new dayThoughts (135, "You can achieve anything you want,  if you help enough people get what they want."),
new dayThoughts (136, "Experience without learning is better than learning without experience."),
new dayThoughts (137, "What lies before us and what lies behind us are  tiny matters compared to what lies within us."),
new dayThoughts (138, "Take care of the minute, for the hours will take care of themselves."),
new dayThoughts (139, "Self trust is the first secret of success."),
new dayThoughts (140, "Do what you can, with what you have, where you are."),
new dayThoughts (141, "The secret of business is to know something that nobody else knows ."),
new dayThoughts (142, "Our patience will achieve more than our force."),
new dayThoughts (143, "There never was a good war, or a bad peace."),
new dayThoughts (144, "A successful person is one who can lay a firm foundation with the bricks that others throw at him."),
new dayThoughts (145, "Without a sense of urgency , desire loses its value."),
new dayThoughts (146, "Obstacles are things a person sees when he takes his eyes off his goal."),
new dayThoughts (147, "Knowledge is a process of piling up facts, wisdom lies in their simplification ."),
new dayThoughts (148, "The more you seek security , the less of it you have. But the more you seek opportunity, the more likely it is that you will achieve the security you desire."),
new dayThoughts (149, "Goodness is the only investment that never fails to return a dividend."),
new dayThoughts (150, "When you know what you want, and you want it badly enough, you'll find a way to get it."),
new dayThoughts (151, "Life would be very pleasant if it were not for its enjoyments."),
new dayThoughts (152, "Good management consists of showing average people how to do the work of superior people."),
new dayThoughts (153, "Laughter,  The most civilized music in the world."),
new dayThoughts (154, "As, mile is the shortest distance between two people."),
new dayThoughts (155, "Any fool can criticize, condemn and complain,  and most fools do."),
new dayThoughts (156, "Being defeated is often a temporary condition . Giving up is what makes it permanent."),
new dayThoughts (157, "It's choice, not chance, that determines your destiny."),
new dayThoughts (158, "Work is man's most natural form of relaxation."),
new dayThoughts (159, "The best feelings are those that have no words to describe them."),
new dayThoughts (160, "There are times when silence has the loudest voice."),
new dayThoughts (161, "One of the best ways to persuade others is with your ears."),
new dayThoughts (162, "A smile is a curve that can set things straight."),
new dayThoughts (163, "Work banishes those three great evils,  boredom, vice and poverty."),
new dayThoughts (164, "The world is dangerous place, not because of those who do evil, but because of those   who look on and do nothing."),
new dayThoughts (165, "God save me from my friend - I can protect myself from my enemies."),
new dayThoughts (166, "Comment is free but facts are on expenses."),
new dayThoughts (167, "The most pathetic person in the world is someone who has sight but not vision."),
new dayThoughts (168, "Love does not consist in gazing at each other but in looking together in the same direction."),
new dayThoughts (169, "Time discovered truth."),
new dayThoughts (170, "Doing what's right isn't the problem. It's knowing what's right ."),
new dayThoughts (171, "There is no worse lie than a truth misunderstood by those who hear it."),
new dayThoughts (172, "To handle yourself, use your head: to handle others, use your heart."),
new dayThoughts (173, "Only those who dare to fail greatly can ever achieve greatly."),
new dayThoughts (174, "If we had no faults, we should not take so much pleasure in noticing them in others ."),
new dayThoughts (175, "The misfortunes that are hardest to bear are those which never come."),
new dayThoughts (176, "No one has ever loved anyone the way everyone wants to be loved."),
new dayThoughts (177, "There is only one success, to be able to spend your life in your own way."),
new dayThoughts (178, "There is no way to peace. Peace is the way."),
new dayThoughts (179, "Not failure but low aim is a crime."),
new dayThoughts (180, "Those who hate you don't win unless you hate them - and then you destroy yourself."),
new dayThoughts (181, "Courage is doing what you're afraid to do. There can be no courage unless you 're scared."),
new dayThoughts (182, "It is not easy to find happiness in ourselves and it is not possible to find it elsewhere."),
new dayThoughts (183, "Genius does what it must and talent does what it can."),
new dayThoughts (184, "No statement can be profound once it has been repeated by others."),
new dayThoughts (185, "Imagination is the highest kite one can fly."),
new dayThoughts (186, "You can clutch the past so tightly to your chest that it leaves your arms too full to embrace the present."),
new dayThoughts (187, "To teach thoroughly to others is the best way to learn for yourself."),
new dayThoughts (188, "We must accept finite disappointment, but we must never lose infinite hope."),
new dayThoughts (189, "The eyes sees only what the mind is prepared to comprehend."),
new dayThoughts (190, "Minds are like parachutes. They only function when they are open."),
new dayThoughts (191, "Of all feats of skill the most difficult is that of being honest."),
new dayThoughts (192, "There is nothing so useless as doing efficiently that which should not be done at all."),
new dayThoughts (193, "If we are incapable of finding peace in ourselves, it is pointless to search it elsewhere."),
new dayThoughts (194, "Art is man's nature: nature is God's art."),
new dayThoughts (195, "The only way to get the best of an argument is to avoid it."),
new dayThoughts (196, "Adversity causes some men to break: others to break records."),
new dayThoughts (197, "The only reward of virtue is virtue:the only way to have a friend is to be one."),
new dayThoughts (198, "Remember, happiness doesn't depend upon who you are or what you have, It depends solely upon what you think."),
new dayThoughts (199, "Only the person who has faith in himself  is able to be faithful to others."),
new dayThoughts (200, "We all take different paths in life, but no matter where we go, we take a little of each other everywhere.")
                           };

        public MySqlConnection myConn = new MySqlConnection();
        public string ConnSt = System.Configuration.ConfigurationManager.ConnectionStrings["EnableIndiaConnectionString"].ToString();

        public MySqlConnection SetLocalConnection()
        {
            string connString = "";
            //            connString = "database=lognfly_lognbuy;Connect Timeout=60;user id=affinity; pwd=aff#321;server=127.0.0.1;";
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["EnableIndiaConnectionString"].ToString();
            if (myConn.State == System.Data.ConnectionState.Closed)
            {
                myConn.ConnectionString = connString;
                try
                {
                    myConn.Open();
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
            
            return myConn;
        }
        public static string EncryptQueryString(string querystring)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(querystring);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes("!5623a#de", saltValueBytes, "SHA1", 2);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(256 / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;


        }

        public static string DecryptQueryString(string encryptedQueryString)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("s@1tValue");

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedQueryString.Replace(" ", "+"));

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes("!5623a#de", saltValueBytes, "SHA1", 2);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(256 / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;

        }

        public static void ShowMessageInAlert(HtmlForm form)
        {
            if (HttpContext.Current.Request.QueryString["msg"] != null)
            {
                string message = DecryptQueryString(HttpContext.Current.Request.QueryString["msg"].ToString());
                //string focusControlID = DecryptQueryString(HttpContext.Current.Request.QueryString["foc"].ToString());
                form.Page.ClientScript.RegisterStartupScript(form.Page.GetType(), "__script", "alert(\"" + message + "\");", true);

                //try
                //{
                //    ((Button)form.Controls[1].FindControl(focusControlID)).Focus();
                //}
                //catch
                //{
                //}
            }
        }


    }
}