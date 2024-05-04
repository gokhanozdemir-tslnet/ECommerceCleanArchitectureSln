"use client"
import styled from "styled-components";
import Link from 'next/link'

export const LinkButton = styled(Link)`
            background-color: orangered;
            color: #f1f1f1;        
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            border: 1px solid transparent;
            padding: .375em .75em;
            font-size: 1rem;
            line-height: 1.5;
            border-radius: .25em;
`;

export const StyledLink = styled(Link)`
  color: #BF4F74;
  font-weight: bold;
`;