CREATE TABLE investidor(        Id                  INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    AUTO_INCREMENT
                                                    COMMENT 'Chave primária',
                                CPF                 VARCHAR(11)
                                                    NOT NULL
                                                    COMMENT 'CPF',
                                nome                VARCHAR(100)
                                                    NOT NULL
                                                    COMMENT 'Nome',
                                renda               DECIMAL(15,2)
                                                    DEFAULT 0.00
                                                    COMMENT 'Renda mensal',
                                aporteMensal        DECIMAL(15,2)
                                                    DEFAULT 0.00
                                                    COMMENT 'Aporte mensal',
                                dataInclusao        TIMESTAMP 
                                                    DEFAULT CURRENT_TIMESTAMP);
ALTER TABLE investidor
    ADD CONSTRAINT pkInvestidor
        PRIMARY KEY( Id );

CREATE INDEX idxInvestidor_CPF
    ON investidor( cpf );





CREATE TABLE contaAplicacao(    Id                  INT         
                                                    UNSIGNED
                                                    NOT NULL 
                                                    AUTO_INCREMENT
                                                    COMMENT 'Chave primaria',
                                nrBanco             VARCHAR(4)
                                                    NOT NULL
                                                    COMMENT 'No. do banco de acordo com a lista do BACEN',
                                banco               VARCHAR(50)
                                                    NOT NULL
                                                    COMMENT 'Nome do banco',
                                nrAgencia           VARCHAR(4)
                                                    NOT NULL
                                                    DEFAULT '0001'
                                                    COMMENT 'No. da Agência',
                                nrConta             VARCHAR(10)
                                                    NOT NULL
                                                    COMMENT 'No. da conta da aplicação',
                                IdInvestidor        INT
                                                    UNSIGNED,
                                dataInclusao        TIMESTAMP 
                                                    DEFAULT CURRENT_TIMESTAMP);

ALTER TABLE contaAplicacao
    ADD CONSTRAINT pkContaAplicacao 
        PRIMARY KEY( Id );

CREATE INDEX idxContaAplic_BcoAgConta
    ON contaAplicacao( nrBanco, nrAgencia, nrConta );

ALTER TABLE contaAplicacao
    ADD CONSTRAINT fkContaAplicacaoInvestidor
    FOREIGN KEY( IdInvestidor )
    REFERENCES Investidor(IdInvestidor);

CREATE TABLE classeAtivo(   id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            descricao       VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Descrição da classe de ativo (Ex: Ação, ETF, FII, Renda Fixa, ...)',
                            tipoRenda       ENUM('F', 'V')
                                            NOT NULL
                                            COMMENT 'Indica se a classe de ativo é de renda fixa (F) ou variável (V)',
                            dataInclusao    TIMESTAMP 
                                                                DEFAULT CURRENT_TIMESTAMP);

CREATE TABLE distribuidor(   id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            nome            VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Nome do distribuidor de ativos de renda fixa (Corretora/Banco)',
                            dataInclusao    TIMESTAMP 
                                            DEFAULT CURRENT_TIMESTAMP);

CREATE TABLE emissor(       id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            nome            VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Nome do emissor de ativos de renda fixa (Empresa, Banco, ...)',
                            dataInclusao    TIMESTAMP 
                                            DEFAULT CURRENT_TIMESTAMP);

CREATE TABLE tipoRendaFixa( id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            descricao       VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Descrição do tipo de renda fixa (Ex: CDB, LCI, LCA, Tesouro Direto, ...)',
                            dataInclusao    TIMESTAMP 
                                            DEFAULT CURRENT_TIMESTAMP);

CREATE TABLE indexador(       id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            descricao       VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Descrição do indexador (Ex: CDI, IPCA, PRÉ...)',
                            dataInclusao    TIMESTAMP 
                                            DEFAULT CURRENT_TIMESTAMP);                                            

CREATE TABLE segmentoFII(   id              INT
                                            UNSIGNED
                                            NOT NULL
                                            AUTO_INCREMENT
                                            COMMENT 'Primary Key',
                            descricao       VARCHAR(100)
                                            NOT NULL
                                            COMMENT 'Descrição do segmento do FII (Ex: Logística, Shoppings, Residencial, ...)',
                            dataInclusao    TIMESTAMP 
                                            DEFAULT CURRENT_TIMESTAMP);


CREATE TABLE ativo(         id                  INT
                                                UNSIGNED
                                                NOT NULL
                                                AUTO_INCREMENT
                                                COMMENT 'Primary Key',
                            descricao           VARCHAR(100)
                                                COMMENT 'Descricao complementar do ativo',
                            idClasseAtivo       INT
                                                UNSIGNED
                                                NOT NULL
                                                COMMENT 'Id da classe do ativo',
                            dataInclusao        TIMESTAMP 
                                                DEFAULT CURRENT_TIMESTAMP);

ALTER TABLE ativo
    ADD CONSTRAINT pkAtivo
    PRIMARY KEY( Id );

ALTER TABLE ativo
    ADD CONSTRAINT fkAtivo_ClasseAtivo
    FOREIGN KEY( idClasseAtivo )
    REFERENCES classeAtivo( Id );

CREATE TABLE rendaFixa(   id               INT
                                                UNSIGNED
                                                NOT NULL
                                                AUTO_INCREMENT
                                                COMMENT 'Primary Key',
                                idAtivo         INT
                                                UNSIGNED
                                                NOT NULL
                                                COMMENT 'Id do ativo de renda fixa',
                                dataVencimento  DATE
                                                NOT NULL
                                                COMMENT 'Data de vencimento do ativo de renda fixa',
                                liquidezDiaria  ENUM('S', 'N')
                                                NOT NULL
                                                DEFAULT 'N'
                                                COMMENT 'Indica se o ativo de renda fixa possui liquidez diária',
                                idEmissor       INT
                                                UNSIGNED
                                                NOT NULL
                                                COMMENT 'Nome do emissor (Empresa, Banco, ...) do ativo de renda fixa',
                                idTipoRendaFixa INT
                                                UNSIGNED
                                                NOT NULL
                                                COMMENT 'Tipo de renda fixa (Ex: CDB, LCI, LCA, Tesouro Direto, ...)',
                                idIndexador     INT
                                                UNSIGNED
                                                NOT NULL
                                                COMMENT 'Indexador (Ex: CDI, IPCA, ...)',
                                taxaJuro        DOUBLE(5,2)
                                                DEFAULT 0.00
                                                NOT NULL
                                                COMMENT 'Taxa de juros anual do ativo de renda fixa',
                                dataInclusao    TIMESTAMP 
                                                DEFAULT CURRENT_TIMESTAMP);

CREATE TABLE rendaVariavel(   id        INT
                                UNSIGNED
                                NOT NULL
                                AUTO_INCREMENT
                                COMMENT 'Primary Key',
                        idAtivo INT
                                UNSIGNED
                                NOT NULL
                                COMMENT 'Id do ativo',
                        ticker  VARCHAR(20)
                                NOT NULL
                                COMMENT 'Código de negociação do ativo de renda variável',     
                        descricao       VARCHAR(100)
                                COMMENT 'Descrição complementar do ativo de renda variável',
                        dataInclusao    TIMESTAMP 
                                DEFAULT CURRENT_TIMESTAMP);

ativoFII(               id              INT
                                        UNSIGNED
                                        NOT NULL
                                        AUTO_INCREMENT
                                        COMMENT 'Primary Key',
                        idAtivo         INT
                                        UNSIGNED
                                        NOT NULL
                                        COMMENT 'Id do ativo',
                        idRendaVariavel  INT
                                        UNSIGNED
                                        NOT NULL
                                        COMMENT 'Id do ativo de renda variável',
                        descricao       VARCHAR(100)
                                        COMMENT 'Descrição complementar do FII',
                        idSegmento      INT
                                        UNSIGNED
                                        NOT NULL
                                        COMMENT 'Segmento do FII (Ex: Logística, Shoppings, Residencial, ...)',
                        precoMedio      DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Preço médio do FII',
                        ultimaCompra    DATE
                                        COMMENT 'Data da última compra do FII',
                        valorUltimaCompra DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Valor da última compra do FII',
                        dyAnual         DECIMAL(5,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Dividend Yield anual do FII',
                        dyMensal         DECIMAL(5,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Dividend Yield mensal do FII',
                        pSobreVP         DECIMAL(5,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Preço sobre valor patrimonial do FII',
                        quotacaoAtual     DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Cotação atual do FII',
                        qtdQuotas        INT
                                        UNSIGNED
                                        DEFAULT 0
                                        NOT NULL
                                        COMMENT 'Quantidade de cotas do FII',
                        pagtoPorQuota     DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Valor do último pagamento por cota do FII',
                        metaRendimentoMensal DECIMAL(5,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Meta de rendimento mensal do FII',
                        dataInclusao    TIMESTAMP 
                                        DEFAULT CURRENT_TIMESTAMP);   

-- PAREI AQUI
ativoAcao(              id              INT
                                        UNSIGNED
                                        NOT NULL
                                        AUTO_INCREMENT
                                        COMMENT 'Primary Key',
                        idAtivo         INT
                                        UNSIGNED
                                        NOT NULL
                                        COMMENT 'Id do ativo',
                        idRendaVariavel  INT
                                        UNSIGNED
                                        NOT NULL
                                        COMMENT 'Id do ativo de renda variável',
                        ticker  VARCHAR(20)
                                NOT NULL
                                COMMENT 'Código de negociação da ação',
                        descricao       VARCHAR(100)
                                COMMENT 'Descrição complementar da ação',
                        precoMedio      DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Preço médio da ação',
                        ultimaCompra    DATE
                                        COMMENT 'Data da última compra da ação',
                        valorUltimaCompra DECIMAL(15,2)
                                        DEFAULT 0.00
                                        NOT NULL
                                        COMMENT 'Valor da última compra da ação',
                        dataInclusao    TIMESTAMP 
                                        DEFAULT CURRENT_TIMESTAMP);                                                 

CREATE TABLE carteiraInvestimento( Id           INT
                                    UNSIGNED
                                    NOT NULL
                                    AUTO_INCREMENT
                                    COMMENT 'Primary key',
                        IdInvestidor    INT
                                    UNSIGNED
                                    NOT NULL
                                    COMMENT 'Id do investidor',
                        nome        VARCHAR(100)
                                    NOT NULL
                                    COMMENT 'Nome da carteira',
                        idDistribuidor  INT
                                    UNSIGNED
                                    NOT NULL
                                    COMMENT 'Nome do distribuidor (Corretora/Banco) do ativo de renda fixa',

                        dataInclusao    TIMESTAMP 
                                        DEFAULT CURRENT_TIMESTAMP);

ALTER TABLE carteiraInvestimento
    ADD CONSTRAINT pkCarteiraInvestimento
    PRIMARY KEY( Id );

ALTER TABLE carteiraInvestimento
    ADD CONSTRAINT fkCartInvest_Investidor
    FOREIGN KEY( IdInvestidor )
    REFERENCES Investidor(Id);

CREATE INDEX idxCartInvest_IdInvestidor
    ON carteiraInvestimento( IdInvestidor );




CREATE TABLE carteiraClasseAtivo(   Id              INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    AUTO_INCREMENT
                                                    COMMENT 'Primary Key',
                                    IdCarteiraInvestimento  INT 
                                                    UNSIGNED
                                                    NOT NULL
                                                    COMMENT 'Id da carteira de investimento',
                                    descricao       VARCHAR(100)
                                                    NOT NULL
                                                    COMMENT 'Descrição da classe de investimento',
                                    percentualComposicao    DOUBLE(6,2)  
                                                    DEFAULT 0.00
                                                    NOT NULL
                                                    COMMENT 'Percentual de composição da classe de ativos na carteira',
                                    dataInclusao    TIMESTAMP 
                                                    DEFAULT CURRENT_TIMESTAMP);

ALTER TABLE carteiraClasseAtivo
    ADD CONSTRAINT pkCarteiraClasseAtivo
        PRIMARY KEY(Id);

ALTER TABLE carteiraClasseAtivo
    ADD CONSTRAINT fkCartClasseAtivo_CartInvest
    FOREIGN KEY( IdCarteiraInvestimento )
    REFERENCES carteiraInvestimento( Id );




CREATE TABLE carteiraComposicaoAtivo(   Id              INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    AUTO_INCREMENT,
                                    IdCarteiraClasseAtivo
                                                    INT
                                                    UNSIGNED
                                                    NOT NULL,
                                    IdATivo         INT 
                                                    UNSIGNED
                                                    NOT NULL
                                                    COMMENT 'Id do ativo',
                                    dataInclusao    TIMESTAMP 
                                                    DEFAULT CURRENT_TIMESTAMP);
                                    
ALTER TABLE carteiraComposicaoAtivo
    ADD CONSTRAINT pkCarteiraComposicaoAtivo
        PRIMARY KEY( Id );

ALTER TABLE carteiraComposicaoAtivo
    ADD CONSTRAINT fkCartCompAtivo_CartClasseAtivo
    FOREIGN KEY( IdCarteiraClasseAtivo )
    REFERENCES carteiraClasseAtivo( Id );

CREATE INDEX idxCartCompAtivo_IdCartClasseAtivo
    ON carteiraComposicaoAtivo( IdCarteiraClasseAtivo );

