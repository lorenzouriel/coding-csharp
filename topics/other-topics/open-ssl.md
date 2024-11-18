# Documentação do OpenSSL, Chave Privada (private-key.key) e Certificado (certificate.pem)
- https://serasa.certificadodigital.com.br/blog/papo-certificado/verificacao-de-assinatura-digital-como-saber-quando-o-certificado-digital-e-valido/#:~:text=Cada%20certificado%20digital%20tem%20uma,o%20certificado%20%C3%A9%20considerado%20v%C3%A1lido.

Essa documentação abrange os conceitos básicos do OpenSSL, a importância da chave privada e do certificado, e os comandos essenciais para gerá-los. Certifique-se de armazenar a chave privada de forma segura e proteger o certificado, pois eles são componentes cruciais da segurança de comunicações criptografadas.

## Tópicos
- OpenSSL
- private-key.key
- certificate.pem
- Comandos para Gerar Chave Privada e Certificado com OpenSSL
- certificate.pfx

## OpenSSL

OpenSSL é uma biblioteca de código aberto que oferece suporte a protocolos de criptografia e segurança, incluindo `SSL/TLS` (`Secure Sockets Layer/Transport Layer Security`), além de fornecer várias utilidades e ferramentas de linha de comando relacionadas à criptografia. É amplamente utilizado para criptografar comunicações de rede, gerar chaves criptográficas, criar certificados digitais e realizar várias operações criptográficas.

- Download: https://sourceforge.net/projects/openssl/files/latest/download

## Chave Privada (`private-key.key`)

Uma chave privada é uma parte fundamental da criptografia assimétrica. É um segredo compartilhado apenas pelo proprietário da chave e é usado para assinar digitalmente dados, descriptografar informações criptografadas e provar a autenticidade do proprietário da chave. No contexto do OpenSSL, a chave privada é frequentemente gerada em pares com uma chave pública correspondente.

A chave privada é estritamente confidencial e nunca deve ser compartilhada com terceiros. É essencial para garantir a segurança das comunicações criptografadas.

## Certificado (`certificate.pem`)

Um certificado é um documento digital que vincula a identidade de uma entidade (como um site, servidor ou pessoa) a uma chave pública. Certificados são usados principalmente para estabelecer conexões seguras pela Internet, autenticar servidores e proteger a integridade dos dados transmitidos. Eles também podem ser usados para autenticar indivíduos em redes corporativas.

O formato PEM (`Privacy-Enhanced Mail`) é um formato comum para armazenar certificados em texto claro, o que torna mais fácil para humanos lerem e compartilharem. O arquivo `certificate.pem` é um arquivo PEM que contém um certificado digital.

## Comandos para Gerar Chave Privada e Certificado com OpenSSL
Aqui estão os comandos OpenSSL para gerar uma chave privada (`private-key.key`) e um certificado (`certificate.pem`):

### 1. Gerar uma chave privada RSA (2048 bits) e um certificado autoassinado:
Este comando gera uma chave privada RSA de 2048 bits e um certificado autoassinado usando essa chave privada.
```sh
openssl req -newkey rsa:2048 -nodes -keyout private-key.key -x509 -days 365 -out certificate.pem

# ou

C:\PATH\openssl > req -newkey rsa:2048 -nodes -keyout private-key.key -x509 -days 365 -out certificate.pem

# ou

req -newkey rsa:2048 -nodes -keyout private-key.key -x509 -days 365 -out certificate.pem -config C:/Users/test/openssl-1.0.2j-fips-x86_64/OpenSSL/bin/openssl.cnf
```

- `req`: Comando para criar ou processar solicitações de certificado.
- `newkey rsa:2048`: Gera uma nova chave privada RSA de 2048 bits.
- `nodes`: Não criptografa a chave privada com uma senha.
- `keyout private-key.key`: Especifica o nome do arquivo para a chave privada.
- `x509`: Gera um certificado autoassinado.
- `days 365`: Define a validade do certificado para 365 dias (um ano).
- `out certificate.pem`: Especifica o nome do arquivo para o certificado.

Certifique-se de personalizar as informações do certificado (como nome comum, organização, etc.) conforme necessário, já que o comando acima solicitará que você forneça essas informações interativamente.

### 2. Gerar por etapas e comandos separados:

#### Passo 1: Gerar a Chave Privada (private-key.key)
```shell
openssl genpkey -algorithm RSA -out private-key.key
```
- Este comando gera uma chave privada RSA não criptografada (sem senha) chamada `private-key.key`.

#### Passo 2: Gerar o Certificado Autoassinado (certificate.pem)
```shell
openssl req -new -key private-key.key -x509 -days 365 -out certificate.pem -subj "/C=BR/ST=SP/L=SBC/O=Waves/OU=TI Dept/CN=localhost"
```
- Este comando gera um certificado autoassinado válido por 365 dias, associando-o à chave privada gerada anteriormente. Ele também define informações de identificação no certificado, como país, estado, cidade, organização e nome comum (CN). Certifique-se de personalizar essas informações conforme necessário.

#### Passo 3: Verificar a Chave Privada e o Certificado
Você pode verificar a chave privada e o certificado gerados usando os seguintes comandos:

**Verificar a Chave Privada:**
```shell
openssl rsa -noout -text -in private-key.key
```
- Este comando exibirá informações sobre a chave privada.

**Verificar o Certificado:**
```shell
openssl x509 -noout -text -in certificate.pem
```
- Este comando exibirá informações sobre o certificado autoassinado.

Com esses passos, você pode gerar uma chave privada e um certificado autoassinado em um ambiente de teste. Lembre-se de substituir as informações de identificação no comando do Passo 2 (subj) pelos valores apropriados para o seu caso de uso de teste. Certifique-se também de armazenar a chave privada com segurança, pois ela é sensível.

## `certificate.pfx`
Um arquivo de **certificado no formato PFX (Personal Information Exchange) é um contêiner que pode armazenar certificados digitais e suas chaves privadas.** Esses certificados são usados principalmente em ambientes que exigem autenticação e segurança, como em conexões seguras na web (**HTTPS**) e em comunicações seguras por email (**S/MIME**).

**O arquivo PFX geralmente contém:**
1. **Certificado Digital:** Uma representação digital de uma entidade, como um site, uma pessoa ou uma organização. O certificado contém informações de identidade e é usado para verificar a autenticidade dessa entidade.

2. **Chave Privada:** A chave privada corresponde à chave pública contida no certificado e é usada para descriptografar informações criptografadas com a chave pública. A posse da chave privada é crucial para provar a identidade associada ao certificado.

3. **Certificados Intermediários (opcional):** Em algumas situações, o arquivo PFX também pode incluir certificados intermediários, que fazem parte da cadeia de certificados para validar a confiança no certificado principal.

O arquivo PFX é frequentemente utilizado em servidores web para configurar a autenticação **SSL/TLS**. Durante o processo de configuração, o administrador do servidor carrega o arquivo PFX no servidor web, associando assim o certificado digital ao servidor. Isso permite que o servidor forneça conexões seguras usando o protocolo HTTPS.