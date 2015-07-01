# original email = pwishnow@interceuticals.com
$email= "pwishnow\@interceuticals.com ";
$tmpfile = "tmp.interceuticals";

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
print MAIL "Subject: $FORM{subject}\n" if ($FORM{subject});
print MAIL "Comments: $FORM{comments}\n" if ($FORM{comments});


   close(MAIL);

   $result = `blat $tmpfile -s "Product Order Form Reply" -t $email`;
  
   unlink($tmpfile);

&thanks;

sub thanks {
   print "Content-type: text/html\n\n";
   print "<HTML><HEAD><TITLE>Numan98</TITLE></HEAD>\n";
   print "<BODY BGCOLOR=#FFFFFF>\n";
   print "<H1>Thank You</H1>\n";
   print "<HR><P>\n";
   print "Your form has been submitted.\n";
   print "Return to the <A HREF=\"http://www.numan98.com/index.html\">Interceuticals
Home Page</A>\n";
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
