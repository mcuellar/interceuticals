# original email = service@interceuticals.com
$email= "service\@interceuticals.com ";
$tmpfile = "tmp.numan98";
$sender = "webmaster\@numan98.com";

if($ENV{'REQUEST_METHOD'} eq 'POST') {
   read(STDIN, $buffer, $ENV{'CONTENT_LENGTH'});
   @pairs=split(/&/, $buffer);
   foreach $pair (@pairs) {
      ($name, $value) = split(/=/, $pair);
      $value =~ tr/+/ /;
      $value =~ s/%([a-fA-F0-9][a-fA-F0-9])/pack("C", hex($1))/eg;
      $FORM{$name} = $value;
   }
}

open(MAIL, ">>$tmpfile") || &error;

print MAIL "-----------------------------\n";
print MAIL "Contact Email: $FORM{email}\n" if ($FORM{email});
print MAIL "First Name: $FORM{firstName}\n" if ($FORM{firstName});
print MAIL "Last Name: $FORM{lastName}\n" if ($FORM{lastName});
print MAIL "Company: $FORM{company}\n" if ($FORM{company});
print MAIL "Address: $FORM{address1}\n" if ($FORM{address1});
print MAIL "Address: $FORM{address2}\n" if ($FORM{address2});
print MAIL "City: $FORM{city}\n" if ($FORM{city});
print MAIL "State: $FORM{state}\n" if ($FORM{state});
print MAIL "Zip: $FORM{zip}\n" if ($FORM{zip});
print MAIL "Country: $FORM{country}\n" if($FORM{country});
print MAIL "Contact Telephone: $FORM{phone}\n" if ($FORM{phone});
print MAIL "-----------------------------\n";
print MAIL "-----------------------------\n";
print MAIL "Subject: $FORM{subject}\n" if ($FORM{subject});
print MAIL "Comments: $FORM{comments}\n" if ($FORM{comments});

$sender = $FORM{email} if ($FORM{email});


   close(MAIL);

   $result = `blat $tmpfile -s "Product Order Form Reply" -t $email -i "Web Response" -f $sender`;
  
   unlink($tmpfile);

&thanks;

sub thanks {
   print "Content-type: text/html\n\n";
   print "<HTML><HEAD><TITLE>Numan98</TITLE></HEAD>\n";
   print "<BODY BGCOLOR=#FFFFFF>\n";
   print "<H1>Thank You</H1>\n";
   print "<HR><P>\n";
   print "Your message has been sent. Thank You.\n";
   print "Click here to <A HREF=\"http://www.numan98.com/index.html\"> Interceuticals Home Page
</A>\n";
   print "</BODY></HTML>\n";
}

   sub error {
      print "Content-type: text/html\n\n";     
      print "<HTML><HEAD><TITLE>Error!</TITLE></HEAD>\n";
      print "<BODY BGCOLOR=WHITE>\n";
      print "<H1>ERROR!!</H1>\n";
      print "An error occured sending your form. Please back up and resubmit.\n";       
      print "</BODY></HTML>\n";
   }  
