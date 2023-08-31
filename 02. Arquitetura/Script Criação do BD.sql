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
                                agencia           VARCHAR(4)
                                                    NOT NULL
                                                    DEFAULT '0001'
                                                    COMMENT 'No. da Agência',
                                conta             VARCHAR(10)
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


CREATE TABLE ativo(             Id                  INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    AUTO_INCREMENT
                                                    COMMENT 'Primary Key',
                                codigoAtivo         VARCHAR(30)
                                                    NOT NULL
                                                    COMMENT 'Código do Ativo (AÇÃO KEPL4, ETF IVVB11, CDB ABC 10% A.A., FII HGLG11, ...)',
                                descricao           VARCHAR(100)
                                                    COMMENT 'Descricao complementar do ativo',
                                dataInclusao        TIMESTAMP 
                                                    DEFAULT CURRENT_TIMESTAMP);

ALTER TABLE ativo
    ADD CONSTRAINT pkAtivo
    PRIMARY KEY( Id );


CREATE TABLE carteiraInvestimento( Id               INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    AUTO_INCREMENT
                                                    COMMENT 'Primary key',
                                    IdInvestidor    INT
                                                    UNSIGNED
                                                    NOT NULL
                                                    COMMENT 'Id do investidor',
                                    nome            VARCHAR(100)
                                                    NOT NULL
                                                    COMMENT 'Nome da carteira',
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




CREATE TABLE carteiraInvestimentoComposicao(   Id              INT
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




CREATE TABLE carteiraAlocacaoAtivo(   Id              INT
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



public class Investidor: BaseEntity
{
    public string? CPF { get; set; }

    public string? Nome { get; set; }

    public decimal Renda { get; set; }

    public decimal AporteMensal{ get; set; }





}
