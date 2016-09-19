
//Carrega a biblioteca do sensor ultrassonico
#include <Ultrasonic.h>
 
//Define os pinos para o trigger e echo
#define pino_trigger 2
#define pino_echo 3
 
//Inicializa o sensor nos pinos definidos acima
Ultrasonic ultrasonic(pino_trigger, pino_echo);
 
void setup()
{
  Serial.begin(9600);
}
 
void loop()
{
  //Le as informacoes do sensor, em cm e pol
  float cmMsec;
  long microsec = ultrasonic.timing();
  cmMsec = ultrasonic.convert(microsec, Ultrasonic::CM);

  //Exibe informacoes no serial monitor
  if(cmMsec >= 15 && cmMsec <= 60)
  {
  Serial.print("w");
  }
  else if (cmMsec < 15 )
  {
  Serial.print("s"); 
  }
  else 
  {
   
  }
  delay(200);
}
